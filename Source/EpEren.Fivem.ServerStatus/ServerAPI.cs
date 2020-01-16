using System.Collections.Generic;
using EpEren.Fivem.ServerStatus.Services.ServerAPI;
using EpEren.Fivem.ServerStatus.Classes.ServerAPI;
using System;

namespace EpEren.Fivem.ServerStatus.ServerAPI
{
    public class Fivem
    {

        public RServer RServer { get; set; }

        public Fivem(string ipport)
        {
            EpHTTP http = new EpHTTP(ipport);

            Info Info= http.GetInfo();
            List<User> Players = http.GetPlayers();
            RServer = new RServer() { isOnline = false };

            if (Info != null && Players != null)
            {
                RServer = new RServer() { isOnline = true, Players = Players, Info = Info };
            }
            
        }

        public RServer GetObject()
        {
            return this.RServer;
        }

        public List<User> GetPlayers()
        {
            return RServer.Players;
        }
        public List<string> GetResources()
        {
            return RServer.Info.resources;
        }
        public List<Var> GetVars()
        {
            var Svar = RServer.Info.vars;
            var Vars = new List<Var>();
            foreach (KeyValuePair<string, object> cvar in Svar)
            {
                Vars.Add(new Var { key = cvar.Key.ToString(), value = cvar.Value.ToString() });
            }

            return Vars;
        }
        public int GetMaxPlayersCount()
        {
            return Convert.ToInt32(GetVars().Find(x => x.key == "sv_maxClients").value);
        }
        public int GetOnlinePlayersCount()
        {
            return RServer.Players.Count;
        }
        public string GetGameName()
        {
            return GetVars().Find(x => x.key == "gamename").value;
        }
        public string GetBanner()
        {
            return GetVars().Find(x => x.key == "banner_detail").value;
        }
        public string GetBannerCon()
        {
            return GetVars().Find(x => x.key == "banner_connecting").value;
        }
        public string GetServerHost()
        {
            return RServer.Info.server;
        }
        public string GetIcon()
        {
            return RServer.Info.icon;
        }
        public int GetVersion()
        {
            return RServer.Info.version;
        }
        public bool GetStatu()
        {
            return RServer.isOnline;
        }
    }
}
