
# Fivem Server Status | Fivem Server Info | C# / Library

---
- [Information](#information)
- [Setup](#setup)
---

# Information
> Version 4.0 | .Net Framework >= 4.5 | .net Core >= 2

# Setup
> Insert 'Release/*.dll' your project. 
> Build this project and get dlls and add reference your projects.

---


## Examples
[Example Launcher](https://github.com/ErenKrt/Fivem-Server-Status/tree/master/Examples/Launcher)

### For BaseAPI
```csharp
using EpEren.Fivem.ServerStatus.BaseAPI;
var New = new Fivem("wz7652"); // Your server code (https://servers.fivem.net/servers)
            if (New.GetStatu())
            {
                var ClassObject = New.GetObject();

                New.GetGameName(); //string
                New.GetGameType(); //string
                New.GetHostName(); //string
                New.GetIconVer();  //int
                New.GetMapName();  //string
                New.GetMaxPlayersCount();  //int
                New.GetOnlinePlayersCount();  //int
                New.GetPlayers(); //object list
                New.GetResources(); //string list
                New.GetServerHost();  //string
                New.GetStatu(); // server online(bool=true) or ofline(bool=false)
                New.GetUpVote(); //int
                New.GetVars(); //object list
                New.GetVars();
                var xD = New.GetVars();
                for (int i = 0; i < xD.Count; i++)
                {
                    var name= xD[i].key;
					var value= xD[i].value;
                }
            }
```
### For ServerAPI
```csharp
using EpEren.Fivem.ServerStatus.ServerAPI;
var New = new Fivem("145.239.150.71:30120"); // Your server ip and port
            if (New.GetStatu())
            {
                var ClassObject = New.GetObject();

                New.GetGameName(); //string
                New.GetMaxPlayersCount();  //int
                New.GetOnlinePlayersCount();  //int
                New.GetPlayers(); //object list
                New.GetResources(); //string list
                New.GetServerHost();  //string
                New.GetStatu(); // server online(bool=true) or ofline(bool=false)
                New.GetVars(); //object list
                New.GetVars();
                var xD = New.GetVars();
                for (int i = 0; i < xD.Count; i++)
                {
                    var name = xD[i].key;
                    var value = xD[i].value;
                }
            }
```
---
Geliştirci: &copy; [ErenKrt](https://www.instagram.com/ep.eren/)
