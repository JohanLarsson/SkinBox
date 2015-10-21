namespace SkinBox.Controls
{
    using System.Collections;
    using System.Windows;
    using System.Windows.Media;

    public static class ColorKey
    {
        public static readonly DependencyProperty RecourceReferenceProperty = DependencyProperty.RegisterAttached(
            "RecourceReference",
            typeof(System.Windows.Expression),
            typeof(ColorKey),
            new PropertyMetadata(null, OnExpressionChanged));

        static ColorKey()
        {
            var brushes = (ResourceDictionary)Application.Current.TryFindResource(Keys.BrushesKey);
            Application.Current.Resources.MergedDictionaries.Add(brushes);
        }

        public static void SetRecourceReference(this SolidColorBrush element, System.Windows.Expression value)
        {
            element.SetValue(RecourceReferenceProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(SolidColorBrush))]
        public static System.Windows.Expression GetRecourceReference(this SolidColorBrush element)
        {
            return (System.Windows.Expression)element.GetValue(RecourceReferenceProperty);
        }

        public static void RefreshBrushes()
        {
            RefreshBrushes(Application.Current.Resources);
        }

        private static void RefreshBrushes(ResourceDictionary dictionary)
        {
            foreach (DictionaryEntry kvp in dictionary)
            {
                var brush = kvp.Value as SolidColorBrush;
                if (brush != null)
                {
                    var recourceReference = GetRecourceReference(brush);
                    if (recourceReference != null)
                    {
                        var clone = brush.Clone();
                        dictionary[kvp.Key] = clone;
                    }
                }
            }
            foreach (var mergedDictionary in dictionary.MergedDictionaries)
            {
                RefreshBrushes(mergedDictionary);
            }
        }

        private static void OnExpressionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var key = GetKeyInResourceDictionary(Application.Current.Resources, o);
            o.SetValue(SolidColorBrush.ColorProperty, e.NewValue);
        }

        private static object GetKeyInResourceDictionary(ResourceDictionary dictionary, object resourceItem)
        {
            foreach (object key in dictionary.Keys)
            {
                if (dictionary[key] == resourceItem)
                {
                    return key;
                }
            }

            if (dictionary.MergedDictionaries != null)
            {
                foreach (var dic in dictionary.MergedDictionaries)
                {
                    var key = GetKeyInResourceDictionary(dic, resourceItem);
                    if (key != null)
                    {
                        return key;
                    }
                }
            }

            return null;
        }
    }
}
