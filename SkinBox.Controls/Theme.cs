namespace SkinBox.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    public static class Theme
    {
        internal static ResourceDictionary Current { get; private set; }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.RegisterAttached(
            "Source",
            typeof (Uri),
            typeof (Theme),
            new FrameworkPropertyMetadata(
                default(Uri),
                FrameworkPropertyMetadataOptions.NotDataBindable, 
                OnSourceChanged));

        public static ICommand ApplyYellowThemeCommand { get; } = CreateThemeCommand(Themes.YellowThemeKey);

        public static ICommand ApplyBlueThemeCommand { get; } = CreateThemeCommand(Themes.BlueThemeKey);

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

        public static void SetSource(this Window element, Uri value)
        {
            element.SetValue(SourceProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(Window))]
        public static Uri GetSource(this Window element)
        {
            return (Uri)element.GetValue(SourceProperty);
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = e.NewValue as Uri;
            if (source != null)
            {
                var theme = new ResourceDictionary {Source = source};
                ApplyTheme(theme);
            }
        }

        private static ICommand CreateThemeCommand(ResourceKey key)
        {
            var theme = (ResourceDictionary)Application.Current.FindResource(key);
            return new ApplyThemeCommand(theme);
        }
    }
}