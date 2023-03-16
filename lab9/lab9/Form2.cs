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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void sign_up_button_Click(object sender, EventArgs e)
        {
            string name =  name_textBox.Text;
            string username = username_textBox.Text;
            string password = password_textBox.Text;
            string retypePassword = re_type_password_textBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(retypePassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (usernameExists(username))
            {
                MessageBox.Show("A user with the same user name already exists.");
                return;
            }

            if (password.Length < 6 || username.Length < 6)
            {
                MessageBox.Show("Username and password must be at least six characters.");
                return;
            }

            if (password != retypePassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            createUser(username, password, name);

            MessageBox.Show("Account created successfully!");


            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private bool usernameExists(string username)
        {
            string filePath = "name_password.txt";
            if (!File.Exists(filePath))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                if (fields[1] == username)
                {
                    return true;
                }
            }

            return false;
        }

        private void createUser(string username, string password, string name)
        {
            string filePath = "name_password.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(username + "," + password + "," + name);
            }
        }

        private void Button2_login_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
