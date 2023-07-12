using Library.UI.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Library.UI
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _mainViewModel;

        public MainViewModel MainViewModel => _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            { 
                this.DragMove(); 
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
