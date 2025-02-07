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

            TextBlock message = new TextBlock
            {
                Text = "Game Started!",
                FontSize = 30,
                Foreground = System.Windows.Media.Brushes.Black,
                VerticalAlignment = VerticalAlignment.Center
            };

            MainArea.Children.Clear();
            MainArea.Children.Add(message);
        }
    }
}