using System;
using System.Windows;

namespace SkinBox.Controls
{
    public partial class Generic
    {
        public Generic()
        {
            var resourceLocator = new Uri(@"/SkinBox.Controls;component/Themes/Skins/Yellow.Theme.xaml", UriKind.Relative);
            var theme = (ResourceDictionary)Application.LoadComponent(resourceLocator);
            Theme.ApplyTheme(theme);
        }
    }
}
