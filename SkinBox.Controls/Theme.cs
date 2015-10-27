namespace SkinBox.Controls
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    public static partial class Theme
    {
        static Theme()
        {
            ApplyYellowThemeCommand  = CreateThemeCommand(YellowThemeKey);
            ApplyBlueThemeCommand  = CreateThemeCommand(BlueThemeKey);
        }

        internal static ResourceDictionary Current { get; private set; }

        public static ICommand ApplyYellowThemeCommand { get; }

        public static ICommand ApplyBlueThemeCommand { get; }

        public static ICommand ApplyThemeCommand { get; } = new ApplyThemeCommand();

        public static ICommand ApplyAccentCommand { get; } = new ApplyAccentCommand();

        public static void ApplyTheme(ResourceDictionary theme)
        {
            Application.Current.Resources.MergedDictionaries.Add(theme);
            if (Current != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(Current);
            }
            Current = theme;
        }

        public static void ApplyAccent(Color accent)
        {
            Application.Current.Resources[Colors.AccentColorKey] = accent;
            Application.Current.Resources[Brushes.AccentBrushKey] =new SolidColorBrush(accent).GetAsFrozen();
            ApplyTheme(Current);
        }

        private static ICommand CreateThemeCommand(ResourceKey key)
        {
            var theme = (ResourceDictionary)Application.Current.FindResource(key);
            return new ApplyThemeCommand(theme);
        }
    }
}