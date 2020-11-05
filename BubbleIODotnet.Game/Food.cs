using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Game
{
    public class Food : GameObject
    {
        public int Reward { get; set; }

        public Food()
        {
            Component = new PictureBox();

            Color = Color.YellowGreen;

            Component.Size = new Size(10, 10);
            Component.BackColor = Color;
            Reward = 5;

            Component.Tag = this;
        }
    }
}
