using RestSharp;
using Newtonsoft.Json;
using EpEren.Fivem.ServerStatus.Classes.BaseAPI;
namespace EpEren.Fivem.ServerStatus.Services.BaseAPI
{
    public class EpHTTP
    {
        RestClient Client;
        RestRequest Request;
        public EpHTTP()
        {
            this.Client = new RestClient("https://servers-live.fivem.net");
            this.Request = new RestRequest("api/servers/single/{code}");
        }

        public RServer GetServer(string Code)
        {
            this.Request.AddOrUpdateParameter("code", Code, ParameterType.UrlSegment);
            try
            {
                return JsonConvert.DeserializeObject<RServer>((this.Client.Execute(Request)).Content);
            }
            catch 
            {
                return null;
            }
                    
        }
    }
}
