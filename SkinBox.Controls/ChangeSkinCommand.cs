using System;
using System.Windows;
using System.Windows.Input;

namespace SkinBox.Controls
{
    internal class ChangeSkinCommand : ICommand
    {
        private readonly ResourceKey _key;

        public ChangeSkinCommand(ResourceKey key)
        {
            _key = key;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var skin = (ResourceDictionary)Application.Current.TryFindResource(_key);
            if (skin != null)
            {
                Application.Current.Resources.MergedDictionaries.Add(skin);
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}