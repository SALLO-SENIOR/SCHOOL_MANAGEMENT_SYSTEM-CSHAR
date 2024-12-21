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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            displayData();
        }
        private void displayData()
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT * FROM users", obj.conn);
            DataTable dt = new DataTable(); // virtual table -- rows & columns
            obj.adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void ClearTextboxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["user_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["password"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["secret_question"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["answer"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["date"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("FADLAN XOGTA SOO DOORO");
                }
                else
                {
                    DialogResult d = MessageBox.Show("Ma Hubtaa inaad saarayso xogtan", "Saaritaanka xogta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        Connnection obj = new Connnection();
                        obj.conn.Open();
                        obj.cmd = new SqlCommand("DELETE FROM users where user_id='" + textBox1.Text + "'", obj.conn);
                        obj.cmd.ExecuteNonQuery();
                        obj.conn.Close();
                        MessageBox.Show("XOGTA WAA LA MASAXAY");
                        displayData();
                        ClearTextboxs();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("FADLAN XOGTA SOO DOORO");
                }
                else
                {
                    Connnection obj = new Connnection();
                    obj.conn.Open();
                    obj.cmd = new SqlCommand("UPDATE users SET username='" + textBox2.Text + "',password='" + textBox3.Text + "',secret_question='" + comboBox1.Text + "',answer='" + textBox5.Text + "',date='" + dateTimePicker1.Value + "' where user_id='" + textBox1.Text + "'", obj.conn);
                    obj.cmd.ExecuteNonQuery();
                    obj.conn.Close();
                    MessageBox.Show("XOGTA Waxba laga bedelay");
                    displayData();
                    ClearTextboxs();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT * FROM users where (username like '" + textBox6.Text + "%') OR (user_id like '" + textBox6.Text + "%')", obj.conn);
            DataSet ds = new DataSet();
            obj.adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            obj.conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }
    }
}
