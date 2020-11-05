using BubbleIODotnet.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleIODotnet.Server
{
    class FieldModel
    {
        public List<Bubble> Players { get; set; }
        public List<Food> Food { get; set; }
        public List<Bomb> Bombs { get; set; }


        public int Width { get; set; }
        public int Height { get; set; }
    }
}
