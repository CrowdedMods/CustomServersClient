using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System.Reflection;
using Reactor;

namespace CustomServersClient
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    public class CustomServersPlugin : BasePlugin
    {
        public const string userDataPath = "UserData";
        public const string customServersFilePath = "CustomServers.json";
        public const string Id = "com.andruzzzhka.customserversclient";

        internal static BepInEx.Logging.ManualLogSource Logger;

        static Harmony _harmony = new Harmony(Id);

        public override void Load()
        {
            Logger = Log;

            _harmony.PatchAll();

            Logger.LogDebug("Applied Harmony patches!");
        }
    }
}
