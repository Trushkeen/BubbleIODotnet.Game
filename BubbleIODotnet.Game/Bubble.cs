using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Game
{
    public class Bubble : GameObject
    {
        private int _size = 20;
        public int Size
        {
            get { return _size; }
            set
            {
                if (Component.Width < 150 || value < _size)
                {
                    _size = value;
                    Component.Size = new Size(value, value);
                }
            }
        }

        public string Username { get; set; }

        public IPEndPoint Endpoint { get; set; }

        public Bubble()
        {
            Component = new PictureBox();

            Component.Size = new Size(_size, _size);

            //Color
            Random rnd = new Random();
            Component.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            Component.Tag = this;
        }
    }
}
