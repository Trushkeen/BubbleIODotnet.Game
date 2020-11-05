using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Game
{
    public class GameObject
    {
        public PictureBox Component { get; set; }

        public Color Color
        {
            get
            {
                return Component.BackColor;
            }
            set
            {
                Component.BackColor = value;
            }
        }

        public Point Location
        {
            get { return Component.Location; }
            set { Component.Location = value; }
        }
    }
}
