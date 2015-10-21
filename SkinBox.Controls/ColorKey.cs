namespace SkinBox.Controls
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public static class ColorKey
    {
        public static readonly DependencyProperty RecourceReferenceProperty = DependencyProperty.RegisterAttached(
            "RecourceReference",
            typeof(System.Windows.Expression),
            typeof(ColorKey),
            new PropertyMetadata(null, OnExpressionChanged));

        public static void SetRecourceReference(this Animatable element, System.Windows.Expression value)
        {
            element.SetValue(RecourceReferenceProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(SolidColorBrush))]
        [AttachedPropertyBrowsableForType(typeof(GradientStop))]
        public static System.Windows.Expression GetRecourceReference(this Animatable element)
        {
            return (System.Windows.Expression)element.GetValue(RecourceReferenceProperty);
        }

        public static void RefreshBrushes()
        {
            //RefreshBrushes(Generic.Instance);
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

                var gradientBrush = kvp.Value as GradientBrush;
                if (gradientBrush != null)
                {
                    if (gradientBrush.GradientStops.Any(x => GetRecourceReference(x) != null))
                    {
                        var clone = gradientBrush.Clone();
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
            var solidColorBrush = o as SolidColorBrush;
            if (solidColorBrush != null)
            {
                solidColorBrush.SetValue(SolidColorBrush.ColorProperty, e.NewValue);
                return;
            }

            var gradientStop = o as GradientStop;
            if (gradientStop != null)
            {
                gradientStop.SetValue(GradientStop.ColorProperty, e.NewValue);
                return;
            }
            throw new InvalidOperationException($"{nameof(ColorKey)}.{RecourceReferenceProperty.Name} can only be set on {nameof(SolidColorBrush)} or {nameof(GradientStop)}");
        }
    }
}
