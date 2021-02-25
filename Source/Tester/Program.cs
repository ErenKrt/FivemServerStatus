using System;
using System.Threading;
using EpEren.Fivem.ServerStatus;
using EpEren.Fivem.ServerStatus.Classes;

namespace Tester
{
    class Program
    {
        public static BaseServer Server { get; set; }
        static void Main(string[] args)
        {

            Server = BaseAPI.Get("qqk7ez");
            if (Server.IsOnline())
            {
                var AllData = Server.Data;
            }

            // With Timer
            Timer t = new Timer(TimerRes, null, 0, 5000);
            Console.ReadLine();
        }
        private static void TimerRes(Object o)
        {
            Console.Clear();
            Console.WriteLine("Checking...");
           
            if (Server.IsOnline())
            {
                Console.Clear();
                Console.WriteLine("Server ONLINE");
                Console.WriteLine("Players: " + Server.Data.Players.Count);
                Console.WriteLine("Players: " + Server.Data.Online); //Alternative
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Server OFFLINE");
            }
            
        }
    }
}
