using EP.Fivem.ServerStatus.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Fivem.ServerStatus.Helpers
{
    internal class ResponseConverter : JsonConverter<Response>
    {
        public override Response? ReadJson(JsonReader reader, Type objectType, Response? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var response = new Response();
            serializer.Populate(jsonObject.CreateReader(), response);

            response.Data.Owner = new()
            {
                ID= jsonObject["Data"]["ownerID"].Value<int>(),
                Name= jsonObject["Data"]["ownerName"].Value<string>(),
                Profile = jsonObject["Data"]["ownerName"].Value<string>(),
                Avatar = jsonObject["Data"]["ownerAvatar"].Value<string>(),
            };

            response.Data.Variables = new List<KeyValuePair<string, string>>();

            foreach (JProperty serverVar in jsonObject["Data"]["vars"].ToArray())
            {
                response.Data.Variables.Add(new(serverVar.Name, serverVar.Value.Value<string>()));
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, Response? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
