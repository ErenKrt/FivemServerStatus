using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EpEren.Fivem.ServerStatus.Classes.ServerAPI
{
    public class Var
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class Info
    {
        public bool enhancedHostSupport { get; set; }
        public string icon { get; set; }
        public List<string> resources { get; set; }
        public string server { get; set; }
        public ExpandoObject vars { get; set; }
        public int version { get; set; }
    }

    public class User
    {
        public string endpoint { get; set; }
        public int id { get; set; }
        public List<string> identifiers { get; set; }
        public string name { get; set; }
        public int ping { get; set; }
    }

    public class RServer
    {
        public bool isOnline { get; set; }
        public Info Info{ get; set; }
        public List<User> Players { get; set; }
    }
}
