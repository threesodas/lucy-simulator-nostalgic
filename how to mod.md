# How to create a mod for Lucy Simulator Nostalgic

## Getting Started

- For LSN, I use [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/).
- LSN is coded in C#. You can follow a [tutorial here](https://www.w3schools.com/cs/default.asp) to learn C#. Everything taught in the tutorial is enough to write a mod.
- Mods are supported with version 1.3.0, and nothing lower. You can write a mod for 1.2.0 or less if you know what you are doing, but it will not be added to the Github page.

## Coding the mod

- Mods are supposed to be altered copies of the original game. To do so, open the SLN file of the unmodded game, edit the main game code, and change it to how you'd like.
- Since LSN uses separate classes, it is important to not change class names or variable names. 

## Saving and crap

### LSN uses separate save text files, save-data.txt and endings.txt. It is recommended to create your own separate text file for saving with your mod.
**To load text files, LSN uses [System.IO](https://docs.microsoft.com/en-us/dotnet/api/system.io?view=net-5.0).**
- Write save
```csharp
TextWriter tw = new StreamWriter("save-data.txt");
tw.WriteLine(yourVariableToSave);
tw.Close(); //Always use tw.Close when you are finished loading save.
```
- Read save
```csharp
TextReader tr = new StreamReader("save-data.txt");
yourVariableGame = tr.ReadLine(); /*
note that ReadLine only works with strings,
so the best way to get an int from readline is to create a string, read the text file,
then use Convert.ToInt32(getMyGameVariable). */
tr.Close();
```
<br />
For resetting game data, this is the simplest code possible:
```csharp
TextWriter tw = new StreamWriter("save-data.txt");
tw.WriteLine(" ");
tw.Close();
Process.Start("Lucy Simulator Nostalgic.exe");
Environment.Exit(0);
```
This is because when booting up the game, it checks if the first line of save-data.txt is "datafilled". If not, it writes it with all stats set to starting state.

<br />
<br />
For more help with modding, please contact me:

- Through Discord (**threesodas#5307**)
- Through Twitter (**@foursoda**)
