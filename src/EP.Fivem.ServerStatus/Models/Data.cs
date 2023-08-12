using EP.Fivem.ServerStatus.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Fivem.ServerStatus.Models
{
    public class Server
    {
        [JsonProperty("private")]
        public bool IsPrivate { get; set; }
        [JsonProperty("fallback")]
        public bool IsFallback { get; set; }
        [JsonProperty("server")]
        public string Name { get; set; }
        public int Clients { get; set; }
        public string GameType { get; set; }
        public string HostName { get; set; }
        public string MapName { get; set; }
        [JsonProperty("sv_maxclients")]
        public int MaxClient { get; set; }
        public string EnhancedHostSupport { get; set; }
        public string RequestSteamTicket { get; set; }
        public ICollection<string> Resources { get; set; }
        public ICollection<string> ConnectEndPoints { get; set; }
        public ICollection<KeyValuePair<string, string>> Variables { get; set; }
        public int SelfReportedClients { get; set; }
        public int UpvotePower { get; set; }
        public int BurstPower { get; set; }
        public DateTime LastSeen { get; set; }
        public Owner Owner { get; set; }
        public ICollection<Player> Players { get; set; }
    }
}

