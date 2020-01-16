using System.Collections.Generic;
using EpEren.Fivem.ServerStatus.Services.BaseAPI;
using EpEren.Fivem.ServerStatus.Classes.BaseAPI;

namespace EpEren.Fivem.ServerStatus.BaseAPI
{
    public class Fivem
    {

        RServer RServer;
        public Fivem(string Code)
        {
            EpHTTP http = new EpHTTP();
            this.RServer= http.GetServer(Code);
            if (this.RServer != null)
            {
                this.RServer.isOnline = true;
            }
            else
            {
                this.RServer = new RServer()
                {
                    isOnline = false
                };

            }
        }
        public RServer GetObject()
        {
            return this.RServer;
        }
        public List<Player> GetPlayers()
        {
            return RServer.Data.players;
        }
        public List<string> GetResources()
        {
            return RServer.Data.resources;
        }
        public List<Var> GetVars()
        {
            var Svar = RServer.Data.vars;
            var Vars = new List<Var>();
            foreach (KeyValuePair<string, object> cvar in Svar)
            {
                Vars.Add(new Var { key = cvar.Key.ToString(), value = cvar.Value.ToString() });
            }

            return Vars;
        }
        public int GetMaxPlayersCount()
        {
            return RServer.Data.sv_maxclients;
        }
        public int GetOnlinePlayersCount()
        {
            return RServer.Data.clients;
        }
        public string GetGameName()
        {
            return RServer.Data.gamename;
        }
        public string GetHostName()
        {
            return RServer.Data.hostname;
        }
        public string GetGameType()
        {
            return RServer.Data.gametype;
        }
        public string GetMapName()
        {
            return RServer.Data.mapname;
        }
        public string GetServerHost()
        {
            return RServer.Data.server;
        }
        public int GetIconVer()
        {
            return RServer.Data.iconVersion;
        }
        public int GetUpVote()
        {
            return RServer.Data.upvotePower;
        }
        public bool GetStatu()
        {
            return RServer.isOnline;
        }
    }
}
