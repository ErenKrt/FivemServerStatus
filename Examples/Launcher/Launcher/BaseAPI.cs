using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EpEren.Fivem.ServerStatus.BaseAPI;
using System.Linq;
namespace KonumXls
{
    public partial class BaseAPI : Form
    {
        public BaseAPI()
        {
            InitializeComponent();
        }

        int TimerVal = 20;
        Fivem Server;
        private void Form1_Load(object sender, EventArgs e)
        {
            Server= new Fivem("wz7652");
            timer1.Start();

            if (Server.GetStatu())
            {
                label2.Text = "Server is Online";
                label2.ForeColor = Color.Green;
                UpdatePlayerList();

                label4.Text = "Game Name: "+Server.GetGameName()+" \n\n";
                label4.Text += "Game Type: " + Server.GetGameType() + " \n\n";
                label4.Text += "Host Name: " + Server.GetHostName() + " \n\n";
                label4.Text += "Icon Version: " + Server.GetIconVer() + " \n\n";
                label4.Text += "Map Name: " + Server.GetMapName() + " \n\n";
                label4.Text += "Server Host Name: " + Server.GetServerHost() + " \n\n";
                label4.Text += "UpVote: " + Server.GetUpVote() + " \n\n";
                label4.AutoSize = true;
                for (int i = 0; i < Server.GetVars().Count; i++)
                {
                    label4.Text += Server.GetVars()[i].key+" => "+Server.GetVars()[i].value+"\n";
                }
            }
            else
            {
                label2.Text = "Server is Offline";
                label2.ForeColor = Color.Red;
            }
        }

        public void UpdatePlayerList()
        {
            label3.Text = "Online: "+Server.GetOnlinePlayersCount().ToString() + " / Max: " + Server.GetMaxPlayersCount() +" Players";
            listView1.Items.Clear();
            
            var PlayerList = Server.GetPlayers();

            for (int i = 0; i < PlayerList.Count; i++)
            {
                string[] row = { PlayerList[i].name.ToString(), PlayerList[i].ping.ToString() };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerVal--;

            label1.Text = "Players (Will update in " + TimerVal.ToString() + ")";

            if(TimerVal <= 0)
            {
                Server= new Fivem("wz7652");
                UpdatePlayerList();
                TimerVal = 20;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var msg = "";
            for (int i = 0; i < Server.GetResources().Count; i++)
            {
                msg += Server.GetResources()[i]+"\n";
            }
            MessageBox.Show(msg);
        }
    }
}
