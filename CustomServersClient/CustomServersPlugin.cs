using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System.Reflection;

namespace CustomServersClient
{
    [BepInPlugin("com.andruzzzhka.customserversclient", "Custom Servers Client", "1.0.0.0")]
    public class CustomServersPlugin : BasePlugin
    {
        public const string userDataPath = "UserData";
        public const string customServersFilePath = "CustomServers.json";

        static internal BepInEx.Logging.ManualLogSource Logger;

        static Harmony _harmony;

        public override void Load()
        {
            Logger = Log;

            _harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "com.andruzzzhka.customserversclient");

            Logger.LogDebug("Applied Harmony patches!");
        }
    }
}
