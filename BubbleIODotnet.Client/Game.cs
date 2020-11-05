using BubbleIODotnet.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Client
{
    public partial class Game : Form
    {
        private Bubble Player;
        
        public Game()
        {
            InitializeComponent();

            ConnectionForm connectionForm = new ConnectionForm();
            connectionForm.ShowDialog();

            //Setup redraw for game field
            Refresher = new Timer();
            Refresher.Interval = 1000 / 60;
            Refresher.Tick += Update;
            Refresher.Start();

            //Initialize food spawner
            ObjectSpawner = new Timer();
            ObjectSpawner.Interval = 2500;
            ObjectSpawner.Tick += SpawnObject;
            ObjectSpawner.Start();

            Bubble player = new Bubble();
            field.Controls.Add(player.Component);
            Player = player;
        }

        
    }
}
