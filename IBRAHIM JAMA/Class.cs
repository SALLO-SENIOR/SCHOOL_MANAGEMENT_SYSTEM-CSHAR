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
    public partial class Class : Form
    {
        public Class()
        {
            InitializeComponent();
            displayData();
        }
        private void displayData()
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT * FROM class_Reg", obj.conn);
            DataTable dt = new DataTable(); // virtual table -- rows & columns
            obj.adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("FADLAN QOR MAGACA Classka");
                }
                else
                {
                    Connnection obj = new Connnection();
                    obj.conn.Open();
                    obj.cmd = new SqlCommand("INSERT INTO class_Reg values('" + textBox2.Text + "','" + dateTimePicker1.Value + "')", obj.conn);
                    obj.cmd.ExecuteNonQuery();
                    obj.conn.Close();
                    MessageBox.Show("Classka XOGTIISA WAA LA SAVE GAREEYEY");
                    displayData();
                  //  ClearTextboxs();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
