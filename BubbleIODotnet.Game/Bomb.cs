using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Game
{
    public class Bomb : GameObject
    {
        public int Damage { get; set; }

        public Bomb()
        {
            Component = new PictureBox();

            Color = Color.Red;

            Component.Size = new Size(10, 10);
            Component.BackColor = Color;
            Damage = 10;

            Component.Tag = this;
        }
    }
}
