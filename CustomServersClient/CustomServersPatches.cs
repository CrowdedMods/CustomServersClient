using HarmonyLib;
using InnerNet;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnhollowerBaseLib;
using CustomServersClient.UI;

using RegionMenuLambda = RegionMenu.IOCEJPCJFKF;
using RegionInfo = KMDGIDEDGGM;
using ServerInfo = EEKGADNPDBH;

namespace CustomServersClient
{
    public static class CustomServersPatches
    {
        public static List<CustomServerInfo> customServers = new List<CustomServerInfo>();

        static RegionInfo[] _defaultRegions = new RegionInfo[3];

        static bool _firstRun = true;
        static ServersManagementForm _managementForm;

        [HarmonyDebug]
        [HarmonyPatch(typeof(InnerNetClient), nameof(InnerNetClient.SetEndpoint), typeof(string), typeof(ushort))]
        public static class InnerNetClientSetEndPointPatch
        {
            public static bool Prefix(string EMFDKKLLHCL, ushort JOBBGKDMALK, ref InnerNetClient __instance)
            {
                var customServer = customServers.FirstOrDefault(x => x.ToString() == EMFDKKLLHCL);

                if (customServer != default)
                {
                    CustomServersPlugin.Logger.LogDebug($"Setting IP and port for custom server \"{customServer.name}\"!");
                    __instance.HECFEPIMCOE = customServer.ip;
                    __instance.DNGDMFHEJBA = customServer.port;
                }
                else
                {
                    __instance.HECFEPIMCOE = EMFDKKLLHCL;
                    __instance.DNGDMFHEJBA = JOBBGKDMALK;
                }

                return false;
            }
        }

        [HarmonyDebug]
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
                        Il2CppReferenceArray<ServerInfo> servers = new ServerInfo[1] { new ServerInfo(customServers[i].name, customServers[i].ToString(), (ushort)customServers[i].port) };

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

        [HarmonyDebug]
        [HarmonyPatch(typeof(RegionMenuLambda), nameof(RegionMenuLambda.Method_Internal_Void_0))]
        public static class RegionMenuChooseOptionPatch
        {
            public static bool Prefix(ref RegionMenuLambda __instance)
            {
                if (__instance.region.NCDMJOGPKOL == "MANAGE_SERVERS")
                {
                    if(_managementForm == null || _managementForm.IsDisposed)
                        _managementForm = new ServersManagementForm();

                    _managementForm.regionMenu = __instance.field_Public_RegionMenu_0;

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
