using HarmonyLib;
using InnerNet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnhollowerBaseLib;
using CustomServersClient.UI;

using RegionMenu = MBLPKNNOCML;
using RegionMenuButtonCallback = MBLPKNNOCML.BLFMBBEHPJN;
using RegionInfo = GCFFHMOOGLH;
using ServerInfo = PDMHFECFBEP;
using ServerManager = CDDEBEELDGO;
using ObjectPoolBehavior = MCBLFCIMCDB;
using PassiveButton = ONEEHOKANFC;

namespace CustomServersClient
{
    public static class CustomServersPatches
    {
        public static List<CustomServerInfo> customServers = new List<CustomServerInfo>();

        static RegionInfo[] _defaultRegions = new RegionInfo[3];

        static bool _firstRun = true;
        static ServersManagementForm _managementForm;

        [HarmonyPatch(typeof(RegionMenu), nameof(RegionMenu.OnEnable))]
        public static class RegionMenuOnEnablePatch
        {
            public static bool forceReloadServers;

            public static bool Prefix(ref RegionMenu __instance)
            {
                ClearOnClickAction(__instance.ButtonPool);

                if (_firstRun)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        _defaultRegions[i] = ServerManager.DefaultRegions[i];
                    }

                    _firstRun = false;
                }

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
                    var regions = new RegionInfo[4 + customServers.Count];

                    regions[0] = new RegionInfo("Manage servers...", "MANAGE_SERVERS", null);

                    for (int i = 0; i < 3; i++)
                    {
                        regions[i + 1] = _defaultRegions[i];
                    }

                    for (int i = 0; i < customServers.Count; i++)
                    {
                        Il2CppReferenceArray<ServerInfo> servers = new ServerInfo[1] { new ServerInfo(customServers[i].name, customServers[i].ip, (ushort)customServers[i].port) };

                        regions[i + 4] = new RegionInfo(customServers[i].name, "0", servers);
                    }

                    ServerManager.DefaultRegions = regions;
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

        
        [HarmonyPatch(typeof(RegionMenuButtonCallback), nameof(RegionMenuButtonCallback.Method_Internal_Void_0))]
        public static class RegionMenuChooseOptionPatch
        {
            public static bool Prefix(ref RegionMenuButtonCallback __instance)
            {
                if (__instance.region.CMADHJOPGHF == "MANAGE_SERVERS")
                {
                    
                    if(_managementForm == null || _managementForm.IsDisposed)
                        _managementForm = new ServersManagementForm();

                    _managementForm.regionMenu = __instance.field_Public_MBLPKNNOCML_0;

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
