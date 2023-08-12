using EP.Fivem.ServerStatus;
using Newtonsoft.Json;

var serverStatus = new FivemServerStatus();

new Timer(TimerDone, null, 0, 5000);

async void TimerDone(object o)
{
    var isOnline = await serverStatus.IsOnline("my533d");
    var server = await serverStatus.Get("my533d");

    Console.WriteLine("IsOnline: " + isOnline);
    Console.WriteLine("Info: " + JsonConvert.SerializeObject(server, Formatting.Indented));

}

Console.ReadLine();