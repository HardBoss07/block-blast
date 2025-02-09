using System.Windows;
using System.Windows.Controls;

namespace block_blast
{

    public partial class MainWindow : Window 
    {
        public MainWindow() 
        {
            InitializeComponent();
        }

        private void startGame(object sender, RoutedEventArgs e) 
        {
            Game game = new Game();

            MainArea.Children.Clear();
            MainArea.Children.Add(game.GameGrid);
        }
    }
}