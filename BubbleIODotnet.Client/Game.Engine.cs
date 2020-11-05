using BubbleIODotnet.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Client
{
    public partial class Game
    {
        Random Rnd = new Random();

        #region Movement Handling

        private bool MoveUp;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            lblKeyPressed.Text = e.KeyData.ToString();
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
            {
                MoveUp = true;
            }
            if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                MoveDown = true;
            }
            if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                MoveLeft = true;
            }
            if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                MoveRight = true;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
            {
                MoveUp = false;
            }
            if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                MoveDown = false;
            }
            if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                MoveLeft = false;
            }
            if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                MoveRight = false;
            }
        }

        #endregion

        #region Refresher

        private Timer Refresher;
        Rectangle PlayerRect;

        private void Update(object sender, EventArgs e)
        {
            if (MoveUp && Player.Location.Y > 0)
            {
                Player.Location = new Point(Player.Location.X, Player.Location.Y - 5);
            }
            if (MoveDown && Player.Location.Y < field.Height - Player.Component.Width)
            {
                Player.Location = new Point(Player.Location.X, Player.Location.Y + 5);
            }
            if (MoveRight && Player.Location.X < field.Width - Player.Component.Width)
            {
                Player.Location = new Point(Player.Location.X + 5, Player.Location.Y);
            }
            if (MoveLeft && Player.Location.X > 0)
            {
                Player.Location = new Point(Player.Location.X - 5, Player.Location.Y);
            }

            PlayerRect = new Rectangle(Player.Location.X, Player.Location.Y,
                Player.Component.Width, Player.Component.Height);

            foreach (Control item in field.Controls)
            {
                Rectangle itemRect = new Rectangle(item.Location.X, item.Location.Y,
                    item.Width, item.Height);

                if (PlayerRect.IntersectsWith(itemRect))
                {
                    if (item.Tag is Food food)
                    {
                        Player.Size += food.Reward;
                        //TODO: send to server
                        item.Dispose();
                    }

                    if (item.Tag is Bubble bubble && Player.Size > bubble.Size)
                    {
                        Player.Size += bubble.Size / 2;
                        //TODO: send to server
                        item.Dispose();
                    }

                    if (item.Tag is Bomb bomb)
                    {
                        Player.Size -= bomb.Damage;
                        //TODO: send to server
                        item.Dispose();
                    }
                }
            }

            lblPlayerPosition.Text = Player.Location.ToString();
            lblPlayerSize.Text = Player.Size.ToString();
        }

        #endregion

        #region Food Spawner

        private Timer ObjectSpawner;

        private void SpawnObject(object sender, EventArgs e)
        {
            Player.Size -= 1;

            double chance = Rnd.NextDouble();

            Point spawnPoint = new Point(Rnd.Next(0, field.Width), Rnd.Next(0, field.Height));

            if (chance < 0.6)
            {
                Food food = new Food();
                field.Controls.Add(food.Component);
                food.Location = spawnPoint;
            }
            else
            {
                Bomb bomb = new Bomb();
                field.Controls.Add(bomb.Component);
                bomb.Location = spawnPoint;
            }
        }

        #endregion
    }
}
