using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EpEren.Fivem.ServerStatus.Classes
{
    public class Server
    {
        private string ip { get; set; }
        private int port { get; set; }
        
        public Server(string ipport)
        {
            var bol = ipport.Split(':');
            ip = bol[0];
            port = Convert.ToInt32(bol[1]);
        }
        public string GetIP()
        {
            return this.ip.ToString();
        }
        public int GetPort()
        {
            return this.port;
        }
    }
}
