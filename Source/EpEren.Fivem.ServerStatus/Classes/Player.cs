using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpEren.Fivem.ServerStatus.Classes
{
    public class Player
    {
        [JsonProperty("endpoint")]
        public string endpoint { get; set; }

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("identifiers")]
        public List<string> Identifiers { get; set; }

        public List<ValueObject> BIdentifiers { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ping")]
        public int Ping { get; set; }
    }
}
