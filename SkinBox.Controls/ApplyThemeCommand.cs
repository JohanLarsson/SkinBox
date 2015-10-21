using System;
using System.Windows;
using System.Windows.Input;

namespace SkinBox.Controls
{
    public class ApplyThemeCommand : ICommand
    {
        public ApplyThemeCommand()
        {
        }

        public ApplyThemeCommand(ResourceDictionary theme)
        {
            Theme = theme;
        }

        public event EventHandler CanExecuteChanged;

        public ResourceDictionary Theme { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var theme = parameter as ResourceDictionary ?? Theme;
            if (theme != null)
            {
                Controls.Theme.Apply(theme);
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}