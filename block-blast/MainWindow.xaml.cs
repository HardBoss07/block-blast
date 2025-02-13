using System.Windows;
using System.Windows.Controls;

namespace block_blast
{

    public partial class MainWindow : Window 
    {

        private Game game;
        public MainWindow() 
        {
            InitializeComponent();

            game = new Game();

            MainArea.Children.Add(game.GameGrid);
        }

        private void startGame(object sender, RoutedEventArgs e) 
        {
            game.update();

            if (game.BlockGrid != null)
            {
                Footer.Children.Clear();
                Footer.Children.Add(game.BlockGrid);

                game.BlockGrid.HorizontalAlignment = HorizontalAlignment.Center;
                game.BlockGrid.VerticalAlignment = VerticalAlignment.Center;
            }
        }
    }
}