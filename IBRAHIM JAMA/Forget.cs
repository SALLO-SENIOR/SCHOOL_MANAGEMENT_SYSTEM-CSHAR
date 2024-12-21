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
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT COUNT(*) FROM USERS where secret_question='" + comboBox1.Text + "' and answer='" + textBox5.Text + "'", obj.conn);
            DataTable dt = new DataTable();
            obj.adapt.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                groupBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("SECRET QUESTION OR ANSWER INCORRECT");
                groupBox2.Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("PASSWORD & CONFIRM PASSWORD NOT EQUAL");
            }
            else
            {
                Connnection obj = new Connnection();
                obj.conn.Open();
                obj.cmd = new SqlCommand("update users set password ='" + textBox1.Text + "' where secret_question='" + comboBox1.Text + "' and answer='" + textBox5.Text + "'", obj.conn);
                obj.cmd.ExecuteNonQuery();
                MessageBox.Show("PASSWORD SUCCESSFULLY UPDATED");
                obj.conn.Close();
                new Form1().Show();
                this.Hide();
            }
        }
    }
}
