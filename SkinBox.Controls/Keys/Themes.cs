﻿using System.Runtime.CompilerServices;
using System.Windows;

namespace SkinBox.Controls
{
    public static class Themes
    {
        public static ResourceKey YellowThemeKey { get; } = CreateResourceKey();

        public static ResourceKey BlueThemeKey { get; } = CreateResourceKey();

        private static ComponentResourceKey CreateResourceKey([CallerMemberName] string caller = null)
        {
            return new ComponentResourceKey(typeof (Themes), caller);
        }
    }
}