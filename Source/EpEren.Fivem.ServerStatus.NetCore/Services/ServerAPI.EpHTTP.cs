using RestSharp;
using Newtonsoft.Json;
using EpEren.Fivem.ServerStatus.Classes.ServerAPI;
using System.Collections.Generic;

namespace EpEren.Fivem.ServerStatus.Services.ServerAPI
{
    public class EpHTTP
    {
        RestClient Client;
        RestRequest Request;
        public EpHTTP(string ipport)
        {
            this.Client = new RestClient("http://"+ipport);
            this.Request = new RestRequest("{path}");
        }

        public Info GetInfo()
        {
            this.Request.AddOrUpdateParameter("path", "info.json", ParameterType.UrlSegment);
            try
            {
                return JsonConvert.DeserializeObject<Info>((this.Client.Execute(Request)).Content);
            }
            catch 
            {
                return null;
            }
                    
        }

        public List<User> GetPlayers()
        {
            this.Request.AddOrUpdateParameter("path", "players.json", ParameterType.UrlSegment);
            try
            {
                return JsonConvert.DeserializeObject<List<User>>((this.Client.Execute(Request)).Content);
            }
            catch
            {
                return null;
            }

        }
    }
}
