using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SkinBox.Controls
{
    public static class Colors
    {
        public static ResourceKey BackgroundColorKey { get; } = CreateResourceKey();

        public static ResourceKey AccentColorKey { get; } = CreateResourceKey();

        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Colors), caller); ;
        }
    }
}