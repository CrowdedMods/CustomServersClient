# Custom Servers Client
An in-game client for custom servers for Among Us. This works on both the Steam and Itch versions of the game.

Works on Steam as of **v2020.12.9s**.  
Works on Itch as of **v2020.11.17i**.

## Installation
1. Download latest [BepInEx (Reactor fork)](https://github.com/NuclearPowered/BepInEx/releases)
2. Extract all files from zipped archive and put them in Among Us directory (where Among Us.exe is)
3. Download [Reactor.dll for 2020.12.9s](https://nightly.link/NuclearPowered/Reactor/actions/runs/593649307) and put it in `YourAmongUsDirectory/BepInEx/plugins`
4. Download latest CustomServersClient.zip from releases, unzip it. 
5. Put unzipped content of `CustomServersClient_v.x.x.x_Steam.zip` in `YourAmongUsDirectory`

*`YourAmongUsDirectory` is your Among Us root directory

## Versions
| Mod version   | Game version  | BepInEx | Downloads |
| ------------- | ------------- | ------- | --------- |
| v1.4.0        | v2020.12.9s  | [Reactor BepInEx](https://github.com/NuclearPowered/BepInEx/releases/download/6.0.0-reactor.16/BepInEx-6.0.0-reactor.16.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.4.0) |
| v1.3.0        | v2020.12.9s  | [BepInEx IL2CPP #325](https://builds.bepis.io/projects/bepinex_be/325/BepInEx_UnityIL2CPP_x86_3d75179_6.0.0-be.325.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.3.0) |
| v1.2.1        | v2020.11.11s and i  | [BepInEx IL2CPP #297](https://builds.bepis.io/projects/bepinex_be/297/BepInEx_UnityIL2CPP_x86_7801f9e_6.0.0-be.297.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.2.1) |
| v1.1.0        | v2020.10.22s  | [IL2CPP Public Preview](https://cdn.discordapp.com/attachments/754333645199900723/757332321169834134/BepInEx_IL2CPP_Preview_x86.7z) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.1.0) |
| v1.0.0        | v2020.09.22s  | [IL2CPP Public Preview](https://cdn.discordapp.com/attachments/754333645199900723/757332321169834134/BepInEx_IL2CPP_Preview_x86.7z) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.0.0) |
*Version v1.4.0 theoretically works with Itch, but wasn't tested.
## Building
1. Install [Reactor](https://docs.reactor.gg/docs/) (Quick Start guide)
2. Open `CustomServersClient.sln` in your favorite IDE
3. Select correct option (for example Steam-Release) and build it.
4. Compiled dll should be automatically copied to your `BepInEx/plugins` folder (Reactor feature)
## Screenshot
![screenshot_0](https://cdn.discordapp.com/attachments/759066383090188308/763331715740729364/unknown.png)

## TO-DO
- Make the mod work with latest Among Us (v2021.3.5)
- Change WinForms to imgui from Reactor
- Make newer screenshot