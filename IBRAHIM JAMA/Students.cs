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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            displayData(); // calling function
            ClassShow();

        }

        private void ClassShow()
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT className From class_Reg", obj.conn);
            DataTable dt = new DataTable();
            obj.adapt.Fill(dt);
            comboBox1.ValueMember = "className";
            comboBox1.DataSource = dt;
            obj.conn.Close();
        }
 
   
        private void displayData()
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT * FROM students", obj.conn);
            DataTable dt = new DataTable(); // virtual table -- rows & columns
            obj.adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void ClearTextboxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("FADLAN QOR MAGACA ARDAYGA");
                }
                else
                {
                    Connnection obj = new Connnection();
                    obj.conn.Open();
                    obj.cmd = new SqlCommand("INSERT INTO students values('" + textBox2.Text + "','" + comboBox1.SelectedValue + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Value + "')", obj.conn);
                    obj.cmd.ExecuteNonQuery();
                    obj.conn.Close();
                    MessageBox.Show("ARDAYGA XOGTIISA WAA LA SAVE GAREEYEY");
                    displayData();
                    ClearTextboxs();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["stude_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["student_name"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["class"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["parent_phone"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["address"].Value.ToString();
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
                        obj.cmd = new SqlCommand("DELETE FROM students where stude_id='" + textBox1.Text + "'", obj.conn);
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
                        obj.cmd = new SqlCommand("UPDATE students SET student_name='" + textBox2.Text + "',class='" + comboBox1.SelectedValue + "',parent_phone='" + textBox4.Text + "',address='" + textBox5.Text + "',date='" + dateTimePicker1.Value + "' where stude_id='" + textBox1.Text + "'", obj.conn);
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
            obj.adapt = new SqlDataAdapter("SELECT * FROM students where (student_name like '" + textBox6.Text + "%') OR (stude_id like '" + textBox6.Text + "%')", obj.conn);
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
