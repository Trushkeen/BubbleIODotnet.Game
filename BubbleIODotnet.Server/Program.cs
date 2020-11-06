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
            int numOfPackage = 0;
            int numOfDisplayedPackage = 5;

            Console.WriteLine("Initialized game");

            while (true)
            {
                var decoded = Encoding.UTF8.GetString(server.Receive(ref anyIP));
                numOfPackage++;

                //deserialize xml info
                var playerInfo = XMLDeserializer.DeserializePlayerInfo(decoded);
                if (!game.IsPlayerPresents(playerInfo.Username))
                {
                    game.Players.Add(playerInfo);
                }

                if (numOfPackage >= numOfDisplayedPackage)
                {
                    Console.WriteLine($"Package receiver: player {playerInfo.Username}, Position {playerInfo.Location}, Size {playerInfo.Size}");
                    numOfPackage = 0;
                }

                foreach (var ip in game.Players)
                {
                    var encoded = Encoding.UTF8.GetBytes(XMLSerializer.SerializePlayerInfo(ip).OuterXml);
                    
                    foreach (var player in game.Players)
                    {
                        server.Send(encoded, encoded.Length, player.Endpoint);
                    }
                }
            }
        }
    }
}
