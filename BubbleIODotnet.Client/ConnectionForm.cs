using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleIODotnet.Client
{
    public partial class ConnectionForm : Form
    {
        public IPAddress Address { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }

        private bool ExitAfterConfirmation = false;

        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Username = tbUsername.Text;

            var splitted = tbAddress.Text.Split(':');

            try
            {
                if (splitted.Length > 2)
                {
                    throw new Exception();
                }

                Address = IPAddress.Parse(splitted[0]);
                Port = Convert.ToInt32(splitted[1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Неправильный формат адреса", "ОШИБКА!!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ExitAfterConfirmation = true;
            this.Close();
        }

        private void ConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitAfterConfirmation)
            {
                var res = MessageBox.Show("Вы точно-точно, ну прямо уверены, что хотите выйти?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbAddress.Text = "127.0.0.1:8000";
            tbUsername.Text = Guid.NewGuid().ToString();
        }
    }
}
