using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SkinBox.Controls
{
    public static class Theme
    {
        private static ResourceDictionary _current;

        public static ICommand ApplyYellowThemeCommand { get; } = CreateThemeCommand(Themes.YellowThemeKey);

        public static ICommand ApplyBlueThemeCommand { get; } = CreateThemeCommand(Themes.BlueThemeKey);

        public static void ApplyTheme(ResourceDictionary theme)
        {
            Application.Current.Resources.MergedDictionaries.Add(theme);
            if (_current != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(_current);
            }
            _current = theme;
        }

        public static void ApplyAccent(Color accent)
        {
            Application.Current.Resources[Colors.AccentColorKey] = accent;
            Application.Current.Resources[Brushes.AccentBrushKey] =new SolidColorBrush(accent).GetAsFrozen();
            ApplyTheme(_current);
        }

        private static ICommand CreateThemeCommand(ResourceKey key)
        {
            var theme = (ResourceDictionary)Application.Current.FindResource(key);
            return new ApplyThemeCommand(theme);
        }
    }
}