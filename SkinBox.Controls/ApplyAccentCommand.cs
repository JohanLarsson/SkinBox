using System;
using System.Windows.Input;
using System.Windows.Media;

namespace SkinBox.Controls
{
    public class ApplyAccentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var brush = parameter as SolidColorBrush;
            if (brush != null)
            {
                Theme.ApplyAccent(brush.Color);
            }

            var color = parameter as Color?;
            if (color != null)
            {
                Theme.ApplyAccent(color.Value);
            }
        }
    }
}