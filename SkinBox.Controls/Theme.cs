using System.Windows;
using System.Windows.Input;

namespace SkinBox.Controls
{
    public static class Theme
    {
        private static ResourceDictionary _current;

        public static ICommand ApplyYellowThemeCommand { get; } = CreateThemeCommand(Themes.YellowThemeKey);

        public static ICommand ApplyBlueThemeCommand { get; } = CreateThemeCommand(Themes.BlueThemeKey);

        public static void Apply(ResourceDictionary theme)
        {
            Application.Current.Resources.MergedDictionaries.Add(theme);
            if (_current != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(_current);
            }
            _current = theme;
        }

        private static ICommand CreateThemeCommand(ResourceKey key)
        {
            var theme = (ResourceDictionary)Application.Current.FindResource(key);
            return new ApplyThemeCommand(theme);
        }
    }
}
