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

    public Game()
    {
       initGame();
    }

    private void initGame()
    {
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

        for (int row = 0; row < GRID_SIZE; row++)
        {
            for (int col = 0; col < GRID_SIZE; col++)
            {
                Border tile = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(195, 195, 195)),
                    CornerRadius = new CornerRadius(4),
                    BorderBrush = new SolidColorBrush(Color.FromRgb(140, 140, 140)),
                    BorderThickness = new Thickness(1),
                    Width = TILE_SIZE,
                    Height = TILE_SIZE
                };

                Grid.SetRow(tile, row);
                Grid.SetColumn(tile, col);

                GameGrid.Children.Add(tile);
            }
        }

        BlockGrid = new Grid
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center
        };

        for (int i = 0; i < 3; i++)
        {
            BlockGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3) });
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

            for (int j = 0; j < random.Next(); j++)
            {
                blocks[i].rotate();
            }
        }
    }

    public void update()
    {
        updateGameGrid();
        updateBlockGrid();
    }

    private void updateGameGrid()
    {
    }

    private void updateBlockGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = i.ToString(),
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 5,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            BlockGrid.Children.Add(textBlock);
        }
    }
}
