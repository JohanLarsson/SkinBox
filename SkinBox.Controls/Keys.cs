namespace SkinBox.Controls
{
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    public static class Keys
    {
        public static ResourceKey BackgroundColorKey { get; } = CreateResourceKey();

        public static ResourceKey BackgroundBrushKey { get; } = CreateResourceKey();

        public static ResourceKey LinearBrushKey { get; } = CreateResourceKey();

        public static ResourceKey CustomControlTemplateKey { get; } = CreateResourceKey();

        public static ResourceKey BlueSkinKey { get; } = CreateResourceKey();
        
        public static ResourceKey BrushesKey { get; } = CreateResourceKey();

        public static ResourceKey YellowSkinKey { get; } = CreateResourceKey();

        public static ICommand SetBlueSkinCommand { get; } = new ChangeSkinCommand(BlueSkinKey);

        public static ICommand SetYellowSkinCommand { get; } = new ChangeSkinCommand(YellowSkinKey);

        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Keys), caller); ;
        }
    }
}
