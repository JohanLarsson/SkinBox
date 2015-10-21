using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SkinBox.Controls;

namespace SkinBox.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnApplyAccentClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var brush = (SolidColorBrush)button.Background;
            Theme.ApplyAccent(brush.Color);
        }
    }
}
