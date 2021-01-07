
# Fivem Server Status | Fivem Server Info | C# / Library

---
- [Information](#information)
- [Setup](#setup)
---

# Information
> Version 3.0 | .Net Framework >= 4.7.2 | .Net Core >= 2 | .Net Core== 5

# Setup
> Insert 'Release/*.dll' your project.
> Build this project and get dlls and add reference your projects.

---

### For BaseAPI
```csharp
			var Server = BaseAPI.Get("5p4q9d"); // Your server code (https://servers.fivem.net/servers)
			if (Server.IsOnline())
            {
                var AllData = Server.Data;
            }
```

### Timer Example

```csharp
			public static BaseServer Server { get; set; }

			Timer t = new Timer(TimerRes, null, 0, 5000);
			
			private static void TimerRes(Object o)
			{
				Console.Clear();
				Console.WriteLine("Checking...");
			   
				if (Server.IsOnline())
				{
					Console.Clear();
					Console.WriteLine("Server ONLINE");
					Console.WriteLine("Players: " + Server.Data.Players.Count);
					Console.WriteLine("Players: " + Server.Data.Online); //Alternative
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Server OFFLINE");
				}
				
			}
```

---
Geliştirci: &copy; [ErenKrt](https://www.instagram.com/ep.eren/)
