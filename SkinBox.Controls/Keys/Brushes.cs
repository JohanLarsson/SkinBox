namespace SkinBox.Controls
{
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class Brushes
    {
        public static ResourceKey BackgroundBrushKey { get; } = CreateResourceKey();

        public static ResourceKey AccentBrushKey { get; } = CreateResourceKey();

        public static ResourceKey LinearBrushKey { get; } = CreateResourceKey();

        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Brushes), caller); ;
        }
    }
}
