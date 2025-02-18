using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

public class Game
{
    private const int GRID_SIZE = 8;
    private const double TILE_SIZE = 50;

    public Grid GameGrid { get; private set; }
    public Grid BlockGrid { get; private set; }

    private Block[] blocks = new Block[3];
    private int[,] gridArray;

    private Point? dragStartPoint = null;

    public Game()
    {
        initGame();
    }

    private void initGame()
    {
        gridArray = new int[GRID_SIZE, GRID_SIZE];
        GameGrid = new Grid
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };

        // rows
        for (int i = 0; i < GRID_SIZE; i++)
        {
            GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(TILE_SIZE) });
        }

        // columns
        for (int i = 0; i < GRID_SIZE; i++)
        {
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(TILE_SIZE) });
        }

        generateGameGrid();

        BlockGrid = new Grid
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center
        };

        for (int i = 0; i < 3; i++)
        {
            BlockGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.1, GridUnitType.Star) });
        }

        setBlocks();
    }

    private void setBlocks()
    {
        blocks = new Block[3];
        Random random = new Random();

        for (int i = 0; i < 3; i++)
        {
            blocks[i] = Block.getRandomBlock();
            blocks[i].setColor();

            int rotations = random.Next(4);
            for (int j = 0; j < rotations; j++)
            {
                blocks[i].rotate();
            }

            var blockGridElement = blocks[i].generateGrid();
            blockGridElement.PreviewMouseDown += Block_PreviewMouseDown;
            blockGridElement.PreviewMouseMove += Block_PreviewMouseMove;
            blockGridElement.Drop += Block_Drop;
            blockGridElement.AllowDrop = true;

            BlockGrid.Children.Add(blockGridElement);
        }
    }

    public void update()
    {
        generateGameGrid();
        updateBlockGrid();
    }

    private void generateGameGrid()
    {
        GameGrid.Children.Clear();

        for (int row = 0; row < GRID_SIZE; row++)
        {
            for (int col = 0; col < GRID_SIZE; col++)
            {
                Border tile = generateTile(gridArray[row, col]);
                Grid.SetRow(tile, row);
                Grid.SetColumn(tile, col);

                GameGrid.Children.Add(tile);
            }
        }
    }

    private Border generateTile(int colorInt)
    {
        Color color = new Color();

        switch (colorInt)
        {
            case 0:
                color = Color.FromRgb(195, 195, 195);
                break;
            case 1:
                color = Colors.Blue;
                break;
            case 2:
                color = Colors.Green;
                break;
            case 3:
                color = Colors.Red;
                break;
            case 4:
                color = Colors.Magenta;
                break;
            case 5:
                color = Colors.Yellow;
                break;
            case 6:
                color = Colors.Orange;
                break;
        }

        Border tile = new Border
        {
            Background = new SolidColorBrush(color),
            CornerRadius = new CornerRadius(4),
            BorderBrush = new SolidColorBrush(Color.FromRgb(140, 140, 140)),
            BorderThickness = new Thickness(1),
            Width = TILE_SIZE,
            Height = TILE_SIZE
        };

        return tile;
    }

    private void updateBlockGrid()
    {
        BlockGrid.Children.Clear();

        for (int i = 0; i < 3; i++)
        {
            Grid blockVisual = blocks[i].generateGrid();
            blockVisual.HorizontalAlignment = HorizontalAlignment.Center;
            blockVisual.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(blockVisual, i);
            BlockGrid.Children.Add(blockVisual);
        }
    }

    private void Block_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        var block = sender as Grid;
        if (block != null)
        {
            dragStartPoint = e.GetPosition(block);

            DataObject data = new DataObject();
            data.SetData("Block", sender);
            DragDrop.DoDragDrop(block, data, DragDropEffects.Move);
        }
    }

    private void Block_PreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (dragStartPoint == null) return;

        var block = sender as Grid;
        Point currentPoint = e.GetPosition(block);

        if (Math.Abs(currentPoint.X - dragStartPoint.Value.X) > 5 || Math.Abs(currentPoint.Y - dragStartPoint.Value.Y) > 5)
        {
            DragDrop.DoDragDrop(block, new DataObject("Block", block), DragDropEffects.Move);
        }
    }

    private void Block_Drop(object sender, DragEventArgs e)
    {
        var block = e.Data.GetData("Block") as Grid;
        if (block != null)
        {
            var pos = e.GetPosition(GameGrid);
            int row = (int)(pos.Y / TILE_SIZE);
            int col = (int)(pos.X / TILE_SIZE);

            if (row >= 0 && col >= 0 && row < GRID_SIZE && col < GRID_SIZE)
            {
                Block droppedBlock = getBlockFromGrid(block);
                if (droppedBlock != null)
                {
                    updateGridArrayWithBlock(row, col, droppedBlock);
                    generateGameGrid();
                }
            }
        }
    }

    private void updateGridArrayWithBlock(int row, int col, Block block)
    {
        for (int r = 0; r < block.Shape.GetLength(0); r++)
        {
            for (int c = 0; c < block.Shape.GetLength(1); c++)
            {
                if (block.Shape[r, c] == 1)
                {
                    if (row + r < GRID_SIZE && col + c < GRID_SIZE)
                    {
                        gridArray[row + r, col + c] = 1;
                    }
                }
            }
        }
    }

    private Block getBlockFromGrid(Grid grid)
    {
        foreach (Block block in blocks)
        {
            var blockGrid = block.generateGrid();
            if (blockGrid == grid) return block;
        }
        return null;
    }
}
