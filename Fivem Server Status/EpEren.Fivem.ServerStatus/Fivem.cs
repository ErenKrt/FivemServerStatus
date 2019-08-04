using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace EpEren.Fivem.ServerStatus
{
    public class Fivem
    {
        private string _ipport { get; set; }

        public Fivem(string ipport)
        {
            _ipport = ipport;
        }


        public object Getİnfo()
        {
            using (HttpRequest req = new HttpRequest())
            {
                var veri = JObject.Parse(Convert.ToString(req.Get("https://servers-live.fivem.net/api/servers/single/" + _ipport)));

                var veriler = veri["Data"];

                dynamic clients = new ExpandoObject();
                clients.OnlineClients = Convert.ToString(veriler["clients"]);
                clients.MaxClients = Convert.ToString(veriler["sv_maxclients"]);

                dynamic server = new ExpandoObject();
                server.Name = Convert.ToString(veriler["hostname"]);
                server.Type = Convert.ToString(veriler["gametype"]);
                server.Map = Convert.ToString(veriler["mapname"]);
                server.More = new ExpandoObject();
                server.More.GameName = Convert.ToString(veriler["gamename"]);
                server.More.Server = Convert.ToString(veriler["server"]);


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

                    dynamic tekli = new ExpandoObject();
                    tekli.ID = Convert.ToString(player["id"]);
                    tekli.Name = Convert.ToString(player["name"]);
                    tekli.Ping = Convert.ToString(player["ping"]);
                    tekli.identifiers = _identifiers;

                    player_list[i] = tekli;
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
                    dynamic tekli = new ExpandoObject();
                    tekli.Name = Convert.ToString(item.Key);
                    tekli.Value = Convert.ToString(item.Value);

                    vars_list[var_i] = tekli;
                    var_i++;
                }

                dynamic donut = new ExpandoObject();
                donut.Server = server;
                donut.Clients = clients;
                donut.Players = player_list;
                donut.Vars = vars_list;
                donut.Resources = resources_list;

                return donut;

            }
        }

    }
}
