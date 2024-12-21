using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IBRAHIM_JAMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT COUNT(*) FROM users where username='" + textBox1.Text + "' and password ='" + textBox2.Text + "'", obj.conn);
            DataTable dt = new DataTable(); //virtual table
            obj.adapt.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                new Dashboard().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("USERNAME OR PASSWORD INCORRECT");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Ma Hubtaa inaad applicationka xidhayso", "xidhida appka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;

            textBox1.Text = Properties.Settings.Default.username;
            textBox2.Text = Properties.Settings.Default.password;
            checkBox2.Checked = Properties.Settings.Default.remembeMe;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                Properties.Settings.Default.username = textBox1.Text;
                Properties.Settings.Default.password = textBox2.Text;
                Properties.Settings.Default.remembeMe = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = string.Empty;
                Properties.Settings.Default.password = string.Empty;
                Properties.Settings.Default.remembeMe = false;
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Forget().Show();
            this.Hide();
        }
    }
}
