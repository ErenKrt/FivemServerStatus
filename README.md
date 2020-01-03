# Fivem Server Status | Fivem Server Info | C# / Library

---
- [Bilgilendirme](#bilgilendirme)
- [Kurulum](#kurulum)
---

# Bilgilendirme
> Version 1 | .Net version >= 4.5

# Kurulum
> Insert 'Release/*.dll' your project. -OR- Build this project and get dlls and add reference your projects.

---


## Kod Kullanımları
```csharp
   using EpEren.Fivem.ServerStatus;
   
    var ServerInfo = new Fivem("145.239.150.71:30120");
   
	if (ServerInfo.GetStatu()) // if server is online
    {     
     ServerInfo.GetGameName(); //string
     ServerInfo.GetGameType(); //string
     ServerInfo.GetHostName(); //string
     ServerInfo.GetIconVer();  //int
     ServerInfo.GetMapName();  //string
     ServerInfo.GetMaxPlayersCount();  //int
     ServerInfo.GetOnlinePlayersCount();  //int
     ServerInfo.GetPlayers(); //object list
     ServerInfo.GetResources(); //string list
     ServerInfo.GetServerHost();  //string
     ServerInfo.GetStatu(); // server online(bool=true) or ofline(bool=false)
     ServerInfo.GetUpVote(); //int
     ServerInfo.GetVars(); //object list

     var xD = ServerInfo.GetVars();
       for (int i = 0; i < xD.Count; i++)
       {
         var name= xD[i].key;
	     var value= xD[i].value;
       }
    }
  
```

---
Geliştirci: &copy; [ErenKrt](https://www.instagram.com/ep.eren/)
