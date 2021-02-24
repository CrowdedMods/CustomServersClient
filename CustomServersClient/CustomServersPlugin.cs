using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using System.Reflection;
using Reactor;

namespace CustomServersClient
{
    [BepInPlugin("com.andruzzzhka.customserversclient")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [ReactorPluginSide(PluginSide.ClientOnly)]
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
