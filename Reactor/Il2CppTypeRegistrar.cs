using System;

namespace ClassicUs.Reactor
{
    internal static class Il2CppTypeRegistrar
    {
        public static void Enqueue(Action register)
        {
            try { register(); }
            catch (Exception e) { ReactorPlugin.Log.LogError("Il2CppTypeRegistrar: " + e); }
        }

        public static void Tick() { }

        public static void FlushAll() { }
    }
}
