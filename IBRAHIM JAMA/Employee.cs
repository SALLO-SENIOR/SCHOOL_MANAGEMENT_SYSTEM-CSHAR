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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            displayData();
        }
        private void displayData()
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.adapt = new SqlDataAdapter("SELECT * FROM Employee", obj.conn);
            DataTable dt = new DataTable(); // virtual table -- rows & columns
            obj.adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
