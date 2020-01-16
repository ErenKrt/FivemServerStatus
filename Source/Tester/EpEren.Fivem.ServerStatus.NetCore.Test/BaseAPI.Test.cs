using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpEren.Fivem.ServerStatus.BaseAPI;

namespace EpEren_Fivem_ServerStatus_NetCore_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
           
            //var New = new Fivem("185.26.146.230:30160");
            var New = new Fivem("wz7652");
            if (New.GetStatu())
            {
                var ClassObject = New.GetObject();

                New.GetGameName(); //string
                New.GetGameType(); //string
                New.GetHostName(); //string
                New.GetIconVer();  //int
                New.GetMapName();  //string
                New.GetMaxPlayersCount();  //int
                New.GetOnlinePlayersCount();  //int
                New.GetPlayers(); //object list
                New.GetResources(); //string list
                New.GetServerHost();  //string
                New.GetStatu(); // server online(bool=true) or ofline(bool=false)
                New.GetUpVote(); //int
                New.GetVars(); //object list
                New.GetVars();
                var xD = New.GetVars();
                for (int i = 0; i < xD.Count; i++)
                {
                    var name= xD[i].key;
					var value= xD[i].value;
                }
            }
            
            
        }
    }
}
