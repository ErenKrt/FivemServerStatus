
# Fivem Server Status | Fivem Server Info | C# / Library

---
- [Information](#information)
- [Setup](#setup)
- [Usage](#usage)
---

# Information
> Version 4.0 | .Net >= 7

# Setup
> Build this project with your spesific .Net version and get dlls and add reference your projects.

---

### Usage
```csharp
using EP.Fivem.ServerStatus;

var serverStatus = new FivemServerStatus();
var isOnline = await serverStatus.IsOnline("my533d");
var server = await serverStatus.Get("my533d"); // Server object
```

---
Developer: &copy; [ErenKrt](https://www.instagram.com/ep.eren/)
