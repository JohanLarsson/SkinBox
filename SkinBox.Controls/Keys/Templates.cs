using System.Runtime.CompilerServices;
using System.Windows;

namespace SkinBox.Controls
{
    public static class Templates
    {
        public static ResourceKey CustomControlTemplateKey { get; } = CreateResourceKey();

        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof (Templates), caller);
        }
    }
}