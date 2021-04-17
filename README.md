[![Our Discord](https://img.shields.io/discord/787008412482797598?color=7289da&label=DISCORD&style=for-the-badge)](https://discord.gg/XEc7PdDTyn)
# Custom Servers Client
An in-game client for custom servers for Among Us. This works on both the Steam and Itch versions of the game.

Works (tested) on Steam from **v2020.12.9s** to **v2021.4.14s**.<br/>
Works on Steam from **v2020.09.22s** to **v2021.4.14s**.<br/>
Works (tested) on Itch as of **v2020.11.17i**.

> :warning: **WARNING** :warning:
> CustomServersClient uses Reactor.
> Reactor currently uses custom, modded handshake even when you only have this mod installed. To play properly also on official Among Us servers:
> 1. Disable anti-cheat, because it gets triggered by CustomRPCs
> 2. Use [patched Reactor](https://cdn.discordapp.com/attachments/787987336846770186/832930668907855872/Reactor-2021.4.12s.dll) without a modded handshake because it wasn't yet implemented in Impostor

## Installation (on Steam)
1. Download latest [BepInEx (Reactor fork)](https://github.com/NuclearPowered/BepInEx/releases)
2. Extract all files from zipped archive and put them in `YourAmongUsDirectory` (where Among Us.exe is)
3. Download [latest Reactor.dll for 2021.4.12s](https://nightly.link/NuclearPowered/Reactor/workflows/main/master) and put it in `YourAmongUsDirectory/BepInEx/plugins`
4. Download latest CustomServersClient.zip from releases, unzip it. 
5. Put unzipped content of `CustomServersClient_vx.x.x_Steam.zip` in `YourAmongUsDirectory\BepInEx\plugins` (for versions v1.5.0 and lower, just put the content in `YourAmongUsDirectory`)

*`YourAmongUsDirectory` is your Among Us root directory

## Versions
| Mod version   | Game version  | BepInEx | Downloads |
| ------------- | ------------- | ------- | --------- |
| v1.7.0        | v2021.4.12 and 4.14  | [Reactor BepInEx](https://github.com/NuclearPowered/BepInEx/releases/download/6.0.0-reactor.18%2Bstructfix/BepInEx-6.0.0-reactor.18+structfix.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.7.0) |
| v1.6.0        | v2021.3.31.3  | [Reactor BepInEx](https://github.com/NuclearPowered/BepInEx/releases/download/6.0.0-reactor.18%2Bstructfix/BepInEx-6.0.0-reactor.18+structfix.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.6.0) |
| v1.5.0        | v2021.3.5     | [Reactor BepInEx](https://github.com/NuclearPowered/BepInEx/releases/download/6.0.0-reactor.16/BepInEx-6.0.0-reactor.16.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.5.0) |
| v1.4.0        | v2020.12.9    | [Reactor BepInEx](https://github.com/NuclearPowered/BepInEx/releases/download/6.0.0-reactor.16/BepInEx-6.0.0-reactor.16.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.4.0) |
| v1.3.0        | v2020.12.9s   | [BepInEx IL2CPP #325](https://builds.bepis.io/projects/bepinex_be/325/BepInEx_UnityIL2CPP_x86_3d75179_6.0.0-be.325.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.3.0) |
| v1.2.1        | v2020.11.11s and i  | [BepInEx IL2CPP #297](https://builds.bepis.io/projects/bepinex_be/297/BepInEx_UnityIL2CPP_x86_7801f9e_6.0.0-be.297.zip) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.2.1) |
| v1.1.0        | v2020.10.22s  | [IL2CPP Public Preview](https://cdn.discordapp.com/attachments/754333645199900723/757332321169834134/BepInEx_IL2CPP_Preview_x86.7z) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.1.0) |
| v1.0.0        | v2020.09.22s  | [IL2CPP Public Preview](https://cdn.discordapp.com/attachments/754333645199900723/757332321169834134/BepInEx_IL2CPP_Preview_x86.7z) | [Releases](https://github.com/CrowdedMods/CustomServersClient/releases/tag/1.0.0) |
*Versions v1.4.0+ theoretically work with Itch, but weren't tested.
## Building
1. Install [Reactor](https://docs.reactor.gg/docs/) (Quick Start guide)
2. Open `CustomServersClient.sln` in your favorite IDE
3. Select correct option (for example Steam-Release) and build it.
4. Compiled dll should be automatically copied to your `BepInEx/plugins` folder (Reactor feature)
## Screenshot
![screenshot_0](https://media.discordapp.net/attachments/787987397203066911/830778408333213716/unknown.png)
## Hall of Fame
- latest version is available thanks to [updated Unify](https://github.com/MoltenMods/Unify)


## TO-DO
- Change WinForms to unstripped imgui from Reactor
