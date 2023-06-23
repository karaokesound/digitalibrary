using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Library.UI.View.Navigation
{
    public partial class NavigationPanel : UserControl
    {
        public NavigationPanel()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var dragWindow = Window.GetWindow(this);
            if (e.ChangedButton == MouseButton.Left)
            {
                dragWindow.DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            var minimizeWindow = Window.GetWindow(this);
            minimizeWindow.WindowState = WindowState.Minimized;
        }
    }
}
