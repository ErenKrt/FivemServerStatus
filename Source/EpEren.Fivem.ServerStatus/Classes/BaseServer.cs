using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace EpEren.Fivem.ServerStatus.Classes
{
    public class BaseServer
    {
        private RestClient _Client { get; set; }
        public string EndPoint { get; set; }
        public BaseServerData Data { get; set; }

        public bool IsOnline()
        {
            if(EndPoint!=null && Data != null)
            {
                if(Data.ConnectionEndpoints.Count > 0)
                {
                    var Url = Data.ConnectionEndpoints[0];

                    if (Url.StartsWith("http") == false)
                    {
                        Url = "http://" + Url;
                    }

                    if (_Client == null)
                    {
                        _Client = new RestClient(Url);
                    }

                    var GetInfoReq = new RestRequest("info.json");
                    GetInfoReq.Timeout = 5000; // Will wait 5 seconds
                    try
                    {
                        var GetInfoRes = _Client.Get(GetInfoReq);
                        if (GetInfoRes.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }

    public class BaseServerData
    {
        [JsonProperty("clients")]
        public string Online { get; set; }
        [JsonProperty("gametype")]
        public string GameType { get; set; }
        [JsonProperty("hostname")]
        public string Name { get; set; }
        [JsonProperty("mapname")]
        public string Map { get; set; }
        [JsonProperty("sv_maxclients")]
        public string MaxPlayer { get; set; }
        [JsonProperty("enhancedHostSupport")]
        public string EnhancedHostSupport { get; set; }
        [JsonProperty("resources")]
        public List<string> Resources { get; set; }

        [JsonProperty("server")]
        public string ServerType { get; set; }


        [JsonProperty("vars")]
        public ExpandoObject Vars { get; set; }

        public List<ValueObject> BVars { get; set; }

        [JsonProperty("players")]
        public List<Player> Players { get; set; }

        [JsonProperty("ownerID")]
        public long OwnerID { get; set; }

        [JsonProperty("connectEndPoints")]
        public List<string> ConnectionEndpoints { get; set; }
        [JsonProperty("iconVersion")]
        public long IconVersion { get; set; }

        public string IconUrl { get; set; }
    }
}
