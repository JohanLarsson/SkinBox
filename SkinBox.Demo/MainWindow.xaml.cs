namespace SkinBox.Demo
{
    using System.Windows;
    using System.Windows.Controls;

    using SkinBox.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)TryFindResource(Keys.YellowSkinKey));
            Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)TryFindResource(Keys.BrushesKey));
            InitializeComponent();
            //var brush = TryFindResource(Keys.BackgroundBrushKey);
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
