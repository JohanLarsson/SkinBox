namespace ResourceBox.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    public class CustomControl : Control
    {
        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl), new FrameworkPropertyMetadata(typeof(CustomControl)));
        }
    }
}
