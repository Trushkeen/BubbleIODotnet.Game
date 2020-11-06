using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BubbleIODotnet.Game
{
    public static class XMLDeserializer
    {
        public static Bubble DeserializePlayerInfo(XmlDocument xml)
        {
            Bubble player = new Bubble();

            player.Size = Convert.ToInt32(xml.GetElementsByTagName(XMLAttributes.PlayerSize).Item(0).InnerText);
            player.Username = xml.GetElementsByTagName(XMLAttributes.Username).Item(0).InnerText;
            int x = Convert.ToInt32(xml.GetElementsByTagName(XMLAttributes.LocationX).Item(0).InnerText);
            int y = Convert.ToInt32(xml.GetElementsByTagName(XMLAttributes.LocationY).Item(0).InnerText);
            player.Location = new System.Drawing.Point(x, y);
            string address = xml.GetElementsByTagName(XMLAttributes.IpAddress).Item(0).InnerText;
            int port = Convert.ToInt32(xml.GetElementsByTagName(XMLAttributes.Port).Item(0).InnerText);
            player.Endpoint = new IPEndPoint(IPAddress.Parse(address), port);

            return player;
        }

        public static Bubble DeserializePlayerInfo(string info)
        {
            var xml = new XmlDocument();
            xml.LoadXml(info);
            return DeserializePlayerInfo(xml);
        }
    }
}
