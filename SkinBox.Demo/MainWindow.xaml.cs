using System.Windows;
using System.Windows.Controls;

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

        private void OnChangeSkinClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var skin = (ResourceDictionary)TryFindResource(button.Content);
            if (skin != null)
            {
                Resources.MergedDictionaries.Add(skin);
            }
        }
    }
}
