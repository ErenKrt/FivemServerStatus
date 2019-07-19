using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace EpEren.Fivem.ServerStatus
{
    class Fivem
    {

        private string _ipport { get; set; }

        public Fivem(string ipport)
        {
            _ipport = ipport;
        }

        
        public object Getİnfo()
        {
            using(HttpRequest req= new HttpRequest())
            {
                var veri = JObject.Parse(Convert.ToString(req.Get("https://servers-live.fivem.net/api/servers/single/" + _ipport)));

                var veriler = veri["Data"];

                var clients = new {OnlineClients=Convert.ToString(veriler["clients"]),MaxClients= Convert.ToString(veriler["sv_maxclients"]) };

                var server = new { Name = Convert.ToString(veriler["hostname"]), Type = Convert.ToString(veriler["gametype"]), Map = Convert.ToString(veriler["mapname"]), More = new { GameName = Convert.ToString(veriler["gamename"]),Server= Convert.ToString(veriler["server"]) } };

                object[] player_list = new object[Convert.ToInt32(veriler["clients"])];

                for (int i = 0; i < Convert.ToInt32(veriler["clients"]); i++)
                {
                    var player = veriler["players"][i];
                    object[] _identifiers = new object[player["identifiers"].Count()];

                    for (int j = 0; j < player["identifiers"].Count(); j++)
                    {
                        var ide = player["identifiers"][j];
                        _identifiers[j] = Convert.ToString(ide);
                    }

                    player_list[i] = new { ID = Convert.ToString(player["id"]), Name = Convert.ToString(player["name"]), Ping = Convert.ToString(player["ping"]), identifiers = _identifiers};
                }

                object[] resources_list = new object[veriler["resources"].Count()];

                for (int i = 0; i < veriler["resources"].Count(); i++)
                {
                    resources_list[i] = Convert.ToString(veriler["resources"][i]);
                }

                object[] vars_list = new object[veriler["vars"].Count()];
                var vars = JObject.Parse(Convert.ToString(veriler["vars"]));
                int var_i = 0;
                foreach (var item in vars)
                {
                    vars_list[var_i] = new[] { Convert.ToString(item.Key) , Convert.ToString(item.Value) };
                    var_i++;
                }

                return new { Server=server,Clients=clients,Players=player_list,Vars=vars_list };
                
            }
        }

    }
}
