﻿namespace SkinBox.Controls
{
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static partial class Theme
    {
        public static ResourceKey YellowThemeKey { get; } = CreateResourceKey();

        public static ResourceKey BlueThemeKey { get; } = CreateResourceKey();

        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof(Theme), caller);
        }
    }
}
