# Custom Servers Client
An in-game client for custom servers for Among Us. This works on both the Steam and Itch versions of the game.

Works on Steam as of **v2020.12.9s**.  
Works on Itch as of **v2020.11.17i**.

## Installation
1. Download latest [BepInEx (Reactor fork)](https://github.com/NuclearPowered/BepInEx/releases)
2. Extract all files from zipped archive and put them in Among Us directory (where Among Us.exe is)
3. Download latest [Reactor.dll](https://nightly.link/NuclearPowered/Reactor/workflows/main/master) and put it in `YourAmongUsDirectory/BepInEx/plugins`
4. Download latest CustomServersClient.zip from releases
5. Unzip it, paste it into `YourAmongUsDirectory`

## Building
1. Install [Reactor](https://docs.reactor.gg/docs/) (Quick Start guide)
2. Open `CustomServersClient.sln` in your favorite IDE
3. Select correct option (for example Steam-Release) and build it.
4. Compiled dll should be automatically copied to your `BepInEx/plugins` folder (Reactor feature)
## Screenshot
![screenshot_0](https://cdn.discordapp.com/attachments/759066383090188308/763331715740729364/unknown.png)

## TO-DO
- Change WinForms to imgui from Reactor
- Make newet screenshot