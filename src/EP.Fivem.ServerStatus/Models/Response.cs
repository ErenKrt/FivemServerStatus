using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Fivem.ServerStatus.Models
{
    internal class Response
    {
        public string EndPoint { get; set; }
        public Server Data { get; set; }
    }
}
