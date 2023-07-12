using System.Diagnostics;
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

        private void Linkedin_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/patryk-karasiewicz-595741272/",
                UseShellExecute = true
            });
        }

        private void Github_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/karaokesound",
                UseShellExecute = true
            });
        }
    }
}
