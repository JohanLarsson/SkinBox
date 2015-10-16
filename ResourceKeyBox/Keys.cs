namespace ResourceKeyBox
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows;

    public static class Keys
    {
        private static readonly Dictionary<string, ComponentResourceKey> Cache = new Dictionary<string, ComponentResourceKey>();

        public static ResourceKey BlueBrushKey => Get();

        private static ComponentResourceKey Get([CallerMemberName] string caller = null)
        {
            ComponentResourceKey key;
            if (!Cache.TryGetValue(caller, out key))
            {
                key = new ComponentResourceKey(typeof(Keys), caller);
                Cache.Add(caller, key);
            }
            return key;
        }
    }
}
