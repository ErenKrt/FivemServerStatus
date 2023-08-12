using EP.Fivem.ServerStatus.Helpers;
using EP.Fivem.ServerStatus.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace EP.Fivem.ServerStatus;
public class FivemServerStatus
{
    private RestClient restClient { get; set; }
    private JsonSerializerSettings jsonSettings { get; set; }
    public FivemServerStatus() {
        restClient = new RestClient(new RestClientOptions()
        {
            BaseUrl = new Uri("https://servers-frontend.fivem.net/api/servers/single"),
            UserAgent= "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36 OPR/101.0.0.0",
        });

        restClient.AddDefaultHeader("Referer", "https://servers.fivem.net/");
        restClient.AddDefaultHeader("Origin", "https://servers.fivem.net");

        jsonSettings= new() {
            TypeNameHandling = TypeNameHandling.All,
        };

        jsonSettings.Converters.Add(new ResponseConverter());

    }

    public async Task<Server> Get(string Code)
    {
        var restRequest = new RestRequest(Code);
        var restResponse= await restClient.GetAsync(restRequest);

        if (restResponse.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Cant fetch fivem API. Returned; " + restResponse.StatusCode);
        }
        var result = JsonConvert.DeserializeObject<Response>(restResponse.Content, jsonSettings);

        return result?.Data;
    }

    public async Task<bool> IsOnline(string Code)
    {
        var server= await Get(Code);
        var endpoint = server.ConnectEndPoints.FirstOrDefault();
        
        if(endpoint is null)
        {
            return false;
        }

        var endpointRequest = new RestRequest("http://" + endpoint + "/info.json");
        try
        {
            await restClient.GetAsync(endpointRequest);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
