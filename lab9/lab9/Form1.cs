using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> users = new List<string>();
        List<string> pass = new List<string>();
        private IEnumerable<string> savedInfo;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string username = username_textbox.Text;
            string password = password_textbox.Text;

            string[] saveInfo = File.ReadAllLines("name_password.txt");

            bool infoMatch = false;

            foreach(string info in savedInfo)
            {
                string[] splitInfo = info.Split(':');
                string savedUsername = splitInfo[0];
                string savedPassword = splitInfo[1];

                if (username == savedUsername && password == savedPassword)
                {
                    infoMatch = true;
                    break;
                }
            }


            if (infoMatch)
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Incorrect username or password!");
            }
        }
    }
}
