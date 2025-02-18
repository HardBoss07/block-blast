using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public class Game
{
    private const int GRID_SIZE = 8;
    private const double TILE_SIZE = 50;

    public Grid GameGrid { get; private set; }
    public Grid BlockGrid { get; private set; }

    private Block[] blocks = new Block[3];
    private int[,] gridArray;

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

        // colums
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

        }
    }

    public void update()
    {
        generateGameGrid();
        updateBlockGrid();
    }

    private void updateGameGrid()
    {
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
}
