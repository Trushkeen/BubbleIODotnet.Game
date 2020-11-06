using BubbleIODotnet.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BubbleIODotnet.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            GameModel game = new GameModel();
            UdpClient server = new UdpClient(8000);
            IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
            int numOfReceivedPackage = 0;
            int numOfDisplayedPackage = 1000;

            Console.WriteLine("Initialized game");

            while (true)
            {
                Bubble playerInfo = null;
                try
                {
                    var decoded = Encoding.UTF8.GetString(server.Receive(ref anyIP));
                    numOfReceivedPackage++;
                    playerInfo = XMLDeserializer.DeserializePlayerInfo(decoded);
                }
                catch
                {
                    Console.WriteLine("Someone disconnected");
                }

                if (playerInfo != null)
                {
                    if (!game.IsPlayerPresents(playerInfo.Username))
                    {
                        game.Players.Add(playerInfo);
                    }

                    var playerUpd = game.FindPlayerByName(playerInfo.Username);
                    playerUpd.Location = playerInfo.Location;
                    playerUpd.Size = playerInfo.Size;

                    if (numOfReceivedPackage >= numOfDisplayedPackage)
                    {
                        //Console.WriteLine($"Package received: player {playerInfo.Username}, Position {playerInfo.Location}, Size {playerInfo.Size}");
                        numOfReceivedPackage = 0;
                    }
                }

                foreach (var player in game.Players)
                {
                    var encoded = Encoding.UTF8.GetBytes(XMLSerializer.SerializePlayerInfo(player).OuterXml);

                    foreach (var ip in game.Players)
                    {
                        server.Send(encoded, encoded.Length, ip.Endpoint);

                        //Console.WriteLine($"Package sent to player {player.Username} about {ip.Username}, Position {player.Location}, Size {player.Size}");
                    }
                }
            }
        }
    }
}
