using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpEren.Fivem.ServerStatus;

namespace Fivem_Server_Status
{
    class Program
    {
        static void Main(string[] args)
        {
            Fivem nf = new Fivem("91.134.243.4:30120");
            dynamic serverinfo = nf.Getİnfo();

            var Players = serverinfo.Players;
            var Server = serverinfo.Server;
            var Client = serverinfo.Clients;
            var Vars = serverinfo.Vars;

            Console.ReadKey();
        }
    }
}
