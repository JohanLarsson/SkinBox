using System.Windows.Input;

namespace SkinBox.Controls
{
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class Keys
    {
        public static ResourceKey BackgroundBrushKey { get; } = Get();

        public static ResourceKey CustomControlTemplateKey { get; } = Get();

        public static ResourceKey BlueSkinKey { get; } = Get();

        public static ICommand SetBlueSkinCommand { get; } = new ChangeSkinCommand(BlueSkinKey);

        public static ResourceKey YellowSkinKey { get; } = Get();

        public static ICommand SetYellowSkinCommand { get; } = new ChangeSkinCommand(YellowSkinKey);

        private static ComponentResourceKey Get([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Keys), caller); ;
        }
    }
}
