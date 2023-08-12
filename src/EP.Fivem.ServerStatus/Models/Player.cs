using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Fivem.ServerStatus.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Ping { get; set; }
        public string Endpoint { get; set; }
        public ICollection<string> Identifiers { get; set; }

    }
}
