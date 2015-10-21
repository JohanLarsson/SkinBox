namespace SkinBox.Controls
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    internal class ChangeSkinCommand : ICommand
    {
        private readonly ResourceKey _key;

        public ChangeSkinCommand(ResourceKey key)
        {
            var skin = Application.Current.TryFindResource(key) as ResourceDictionary;
            if (!IsSkin(skin))
            {
                throw new ArgumentException("Skin dictionary must end with .Skin.xaml. Example Dark.Skin.xaml");
            }
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
                var old = Application.Current.Resources.MergedDictionaries.FirstOrDefault(IsSkin);
                Application.Current.Resources.MergedDictionaries.Add(skin);
                if (old != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(old);
                }
                ColorKey.RefreshBrushes();
            }
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private static bool IsSkin(ResourceDictionary dictionary)
        {
            if (dictionary == null)
            {
                return false;
            }
            return dictionary.Source.OriginalString.EndsWith(".Skin.xaml");
        }
    }
}