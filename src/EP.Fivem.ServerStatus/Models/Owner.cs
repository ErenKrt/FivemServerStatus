
using EP.Fivem.ServerStatus.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EP.Fivem.ServerStatus.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Avatar { get; set; }
    }
}
