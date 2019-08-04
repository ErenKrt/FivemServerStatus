# C# Fivem Server Status / Library 
 - [Bilgilendirme](#bilgilendirme)
 - [Kurulum](#kurulum)

## Bilgilendirme
Version 1 | Min: .Net version 4.5
[PHP Version](https://github.com/ErenKrt/Fivem-Server-Status-PHP)
## Kurulum

[Release](https://github.com/ErenKrt/Fivem-Server-Status/releases)

İnsert 'Release/Fivem Server Status.dll' your project.
-OR-
Build this project and get 'Dll' file.

## Kullanım

```csharp
using EpEren.Fivem.ServerStatus;

Fivem nf = new Fivem("YOUR SERVER İP:PORT"); // Test 91.134.243.4:30120
dynamic serverinfo = nf.Getİnfo();

var Players = serverinfo.Players;
var Server = serverinfo.Server;
var Client = serverinfo.Clients;
var Vars = serverinfo.Vars;
var Resources = serverinfo.Resources;
```

Geliştirci: &copy; [ErenKrt](https://www.instagram.com/ep.eren/)
