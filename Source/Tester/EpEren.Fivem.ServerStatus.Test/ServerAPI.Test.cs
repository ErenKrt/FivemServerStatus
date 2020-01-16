using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpEren.Fivem.ServerStatus.ServerAPI;

namespace EpEren_Fivem_ServerStatus_NetCore_Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod()
        {
             
            var New = new Fivem("145.239.150.71:30120");
            if (New.GetStatu())
            {
                var ClassObject = New.GetObject();

                New.GetGameName(); //string
                New.GetMaxPlayersCount();  //int
                New.GetOnlinePlayersCount();  //int
                New.GetPlayers(); //object list
                New.GetResources(); //string list
                New.GetServerHost();  //string
                New.GetStatu(); // server online(bool=true) or ofline(bool=false)
                New.GetVars(); //object list
                New.GetVars();
                var xD = New.GetVars();
                for (int i = 0; i < xD.Count; i++)
                {
                    var name = xD[i].key;
                    var value = xD[i].value;
                }
            }


        }
    }
}
