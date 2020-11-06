using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BubbleIODotnet.Game
{
    public static class XMLSerializer
    {
        //TODO: color
        public static XmlDocument SerializePlayerInfo(Bubble player)
        {
            XmlDocument xml = new XmlDocument();
            XmlElement body = xml.CreateElement(XMLAttributes.PlayerInfo);
            xml.AppendChild(body);

            XmlNode username = xml.CreateNode(XmlNodeType.Element, XMLAttributes.Username, string.Empty);
            body.AppendChild(username);
            XmlText usernameContent = xml.CreateTextNode(player.Username);
            username.AppendChild(usernameContent);

            XmlNode locationX = xml.CreateNode(XmlNodeType.Element, XMLAttributes.LocationX, string.Empty);
            body.AppendChild(locationX);
            XmlText locationXContent = xml.CreateTextNode(player.Location.X.ToString());
            locationX.AppendChild(locationXContent);

            XmlNode locationY = xml.CreateNode(XmlNodeType.Element, XMLAttributes.LocationY, string.Empty);
            body.AppendChild(locationY);
            XmlText locationYContent = xml.CreateTextNode(player.Location.Y.ToString());
            locationY.AppendChild(locationYContent);

            XmlNode size = xml.CreateNode(XmlNodeType.Element, XMLAttributes.PlayerSize, string.Empty);
            body.AppendChild(size);
            XmlText sizeContent = xml.CreateTextNode(player.Size.ToString());
            size.AppendChild(sizeContent);

            XmlNode address = xml.CreateNode(XmlNodeType.Element, XMLAttributes.IpAddress, string.Empty);
            body.AppendChild(address);
            XmlText addressContent = xml.CreateTextNode(player.Endpoint.Address.ToString());
            address.AppendChild(addressContent);

            XmlNode port = xml.CreateNode(XmlNodeType.Element, XMLAttributes.Port, string.Empty);
            body.AppendChild(port);
            XmlText portContent = xml.CreateTextNode(player.Endpoint.Port.ToString());
            port.AppendChild(portContent);

            return xml;
        }
    }
}
