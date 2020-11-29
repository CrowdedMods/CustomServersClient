# Custom Servers Client
An in-game client for custom servers for Among Us. This works on both the Steam and Itch versions of the game.

Works on Steam as of **v2020.11.17s**.
Works on Itch as of **v2020.11.17i**.

## Building

1. Download the source code
2. Add references to the required DLLs, add the paths for `Assembly-CSharp-Steam` and `Assembly-CSharp-Itch` by manually editing `CustomServersClient.csproj` in a text editor. (You don't need to add both if you're only building one.)
3. Change the Solution Configuration depending on what version you want to build (both debug and release versions exist for both versions).
4. Build the solution, `CustomServersClient.dll` will be in it's own directory depending on the version built.

## Screenshot
![screenshot_0](https://cdn.discordapp.com/attachments/759066383090188308/763331715740729364/unknown.png)
