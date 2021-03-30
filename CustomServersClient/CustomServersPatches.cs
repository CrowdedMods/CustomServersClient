using HarmonyLib;
using InnerNet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using UnhollowerBaseLib;
using CustomServersClient.UI;
using Il2CppSystem.Diagnostics.Tracing;
using Il2CppSystem.Globalization;

namespace CustomServersClient
{
    public static class CustomServersPatches
    {
        public static List<CustomServerInfo> customServers = new List<CustomServerInfo>();

        private static IRegionInfo[] _defaultRegions = ServerManager.DefaultRegions;
        
        static ServersManagementForm _managementForm;

        [HarmonyPatch(typeof(RegionMenu), nameof(RegionMenu.OnEnable))]
        public static class RegionMenuOnEnablePatch
        {
            public static bool forceReloadServers;

            public static bool Prefix(ref RegionMenu __instance)
            {
                ClearOnClickAction(__instance.ButtonPool);

                Directory.CreateDirectory(CustomServersPlugin.userDataPath);

                if (File.Exists(Path.Combine(CustomServersPlugin.userDataPath, CustomServersPlugin.customServersFilePath)))
                {
                    customServers = JsonConvert.DeserializeObject<List<CustomServerInfo>>(File.ReadAllText(Path.Combine(CustomServersPlugin.userDataPath, CustomServersPlugin.customServersFilePath)));
                    CustomServersPlugin.Logger.LogDebug("Loaded custom servers list from file!");
                }
                else
                {
                    CustomServersPlugin.Logger.LogWarning("Custom servers list file not found!");
                }

                if (ServerManager.DefaultRegions.Count != 4 + customServers.Count || forceReloadServers)
                {
                    var regions = new IRegionInfo[4 + customServers.Count];

                    regions[0] = new DnsRegionInfo("Manage servers...", "Manage servers...", StringNames.NoTranslation,
                        "Manage servers...").Cast<IRegionInfo>();

                    for (int i = 0; i < 3; i++)
                    {
                        regions[i + 1] = _defaultRegions[i];
                    }

                    for (int i = 0; i < customServers.Count; i++)
                    {
                        Il2CppReferenceArray<ServerInfo> servers = new ServerInfo[1] { new ServerInfo(customServers[i].name, customServers[i].ip, (ushort)customServers[i].port) };

                        regions[i + 4] = new DnsRegionInfo(customServers[i].ip, customServers[i].name, StringNames.NoTranslation, servers).Cast<IRegionInfo>();
                    }

                    ServerManager.DefaultRegions = regions;
                    ServerManager.Instance.AvailableRegions = regions;
                    ServerManager.Instance.SaveServers();
                }

                return true;
            }

            public static void ClearOnClickAction(ObjectPoolBehavior buttonPool)
            {
                foreach (var button in buttonPool.activeChildren)
                {
                    var buttonComponent = button.GetComponent<PassiveButton>();
                    if (buttonComponent != null)
                        buttonComponent.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                }

                foreach (var button in buttonPool.inactiveChildren)
                {
                    var buttonComponent = button.GetComponent<PassiveButton>();
                    if (buttonComponent != null)
                        buttonComponent.OnClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                }
            }
        }

        
        [HarmonyPatch(typeof(RegionMenu.c__DisplayClass2_0), "Method_Internal_Void_0")]
        public static class RegionMenuChooseOptionPatch
        {
            public static bool Prefix(ref RegionMenu.c__DisplayClass2_0 __instance)
            {
                if (__instance.region.PingServer == "Manage servers...")
                {
                    if (_managementForm == null || _managementForm.IsDisposed)
                        _managementForm = new ServersManagementForm();

                    _managementForm.regionMenu = __instance.__this;

                    if (_managementForm.Visible)
                        _managementForm.Focus();
                    else
                        _managementForm.ShowDialog();

                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
