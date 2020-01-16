using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EpEren.Fivem.ServerStatus.Classes.BaseAPI
{
    
    public class Var
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class Player
    {
        public string endpoint { get; set; }
        public int id { get; set; }
        public List<string> identifiers { get; set; }
        public string name { get; set; }
        public int ping { get; set; }
    }

    public class Data
    {
        public int sv_maxclients { get; set; }
        public int clients { get; set; }
        public string gamename { get; set; }
        public int protocol { get; set; }
        public string hostname { get; set; }
        public string gametype { get; set; }
        public string mapname { get; set; }
        public bool enhancedHostSupport { get; set; }
        public List<string> resources { get; set; }
        public string server { get; set; }
        public ExpandoObject vars { get; set; }
        public List<Player> players { get; set; }
        public int upvotePower { get; set; }
        public int svMaxclients { get; set; }
        public DateTime lastSeen { get; set; }
        public int iconVersion { get; set; }
    }
    public class RServer
    {
        public bool isOnline { get; set; }
        public string EndPoint { get; set; }
        public Data Data { get; set; }
    }
}
