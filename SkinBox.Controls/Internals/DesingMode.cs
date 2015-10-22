namespace SkinBox.Controls.Internals
{
    using System.ComponentModel;
    using System.Windows;

    public static class DesingMode
    {
        private static readonly DependencyObject DependencyObject = new DependencyObject();

        public static bool IsDesignMode => DesignerProperties.GetIsInDesignMode(DependencyObject);
    }
}
