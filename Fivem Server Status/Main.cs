
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using xNet;
namespace EpEren.Fivem.ServerStatus
{
    public class Fivem
    {

        Classes.Server Server;
        Classes.RServer RServer;
        public Fivem(string ipport)
        {
            Server = new Classes.Server(ipport);

            using (HttpRequest req = new HttpRequest())
            {
                try
                {
                    this.RServer = JsonConvert.DeserializeObject<Classes.RServer>(Convert.ToString(req.Get("https://servers-live.fivem.net/api/servers/single/" + Server.GetIP() + ":" + Server.GetPort())));
                    this.RServer.isOnline = true;
                }
                catch
                {
                    this.RServer = new Classes.RServer();
                    this.RServer.isOnline = false;

                }
            }
        }
        
        public List<Classes.Player> GetPlayers()
        {
            return RServer.Data.players;
        }
        public List<string> GetResources()
        {
            return RServer.Data.resources;
        }
        public List<Classes.Var> GetVars()
        {
            var Svar = RServer.Data.vars;
            var Vars = new List<Classes.Var>();
            foreach (KeyValuePair<string, object> cvar in Svar)
            {
                Vars.Add(new Classes.Var { key = cvar.Key.ToString(), value = cvar.Value.ToString() });
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
