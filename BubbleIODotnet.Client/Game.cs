using BubbleIODotnet.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Client
{
    public partial class Game : Form
    {
        private Bubble Player;
        private List<Bubble> OtherPlayers = new List<Bubble>();

        private UdpClient Client;
        private IPAddress ServerAddress;
        private int ServerPort;

        private Timer ServerUpdateTimer;

        public Game()
        {
            InitializeComponent();

            ConnectionForm connectionForm = new ConnectionForm();
            connectionForm.ShowDialog();
            ServerAddress = connectionForm.Address;
            ServerPort = connectionForm.Port;
            IPEndPoint ep = new IPEndPoint(ServerAddress, ServerPort);
            Client = new UdpClient();
            Client.Connect(ep);

            //Setup redraw for game field
            Refresher = new Timer();
            Refresher.Interval = 1000 / 60;
            Refresher.Tick += Update;
            Refresher.Start();

            //Initialize food spawner
            ObjectSpawner = new Timer();
            ObjectSpawner.Interval = 2500;
            ObjectSpawner.Tick += SpawnObject;
            ObjectSpawner.Start();

            //Setup server updating
            ServerUpdateTimer = new Timer();
            ServerUpdateTimer.Interval = 1000 / 20;
            ServerUpdateTimer.Tick += StartServerMessaging;
            System.Threading.Thread thread = new System.Threading.Thread(UpdatePlayersList);

            Bubble player = new Bubble();
            player.Endpoint = (IPEndPoint)Client.Client.LocalEndPoint;
            player.Username = connectionForm.Username;
            field.Controls.Add(player.Component);
            Player = player;

            UpdatePlayersList();
        }

        private void StartServerMessaging(object sender, EventArgs e)
        {
            UpdatePlayersList();
        }

        private void UpdatePlayersList()
        {
            if (!ServerUpdateTimer.Enabled)
            {
                ServerUpdateTimer.Start();
            }

            var playerInfo = XMLSerializer.SerializePlayerInfo(Player).OuterXml;
            var bytes = Encoding.UTF8.GetBytes(playerInfo);
            Client.Send(bytes, bytes.Length);

            IPEndPoint ep = new IPEndPoint(ServerAddress, ServerPort);
            var decoded = XMLDeserializer.DeserializePlayerInfo(Encoding.UTF8.GetString(Client.Receive(ref ep)));
            UpdatePlayer(decoded);
        }

        private void UpdatePlayer(Bubble bubble)
        {
            if (bubble.Username != Player.Username)
            {
                for (int i = 0; i < OtherPlayers.Count; i++)
                {
                    if (bubble.Username == OtherPlayers[i].Username)
                    {
                        OtherPlayers[i] = bubble;
                        return;
                    }
                }
                OtherPlayers.Add(bubble);
                field.Controls.Add(bubble.Component);
            }
        }
    }
}
