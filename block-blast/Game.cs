using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

public class Game
{
    private const int GRID_SIZE = 8;
    private const double TILE_SIZE = 50;

    public Grid GameGrid { get; private set; }

    public Game()
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
    }
}
