using BubbleIODotnet.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleIODotnet.Server
{
    class GameModel
    {
        public List<Bubble> Players { get; set; } = new List<Bubble>();
        public List<Food> Food { get; set; } = new List<Food>();
        public List<Bomb> Bombs { get; set; } = new List<Bomb>();


        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsPlayerPresents(string username)
        {
            bool found = false;
            foreach (var item in Players)
            {
                if (item.Username == username)
                {
                    found = true;
                    return found;
                }
            }
            return found;
        }
    }
}
