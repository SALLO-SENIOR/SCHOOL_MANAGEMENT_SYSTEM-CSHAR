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
    public partial class BACKUP_RESTORE : Form
    {
        public BACKUP_RESTORE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "BACKUP FILES *|.BAK";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connnection obj = new Connnection();
            obj.conn.Open();
            obj.cmd = new SqlCommand("BACKUP DATABASE School_System TO DISK ='"+textBox1.Text+"' ", obj.conn);
            obj.cmd.ExecuteNonQuery();
            obj.conn.Close();
            MessageBox.Show("BACKUPKA WAA LA QAADAY");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdl = new OpenFileDialog
            {
                Filter = "SQL BACKUP RESTORE |*.BAK",
                Title = "DATABASE RESTORE"
            };
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = fdl.FileName;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connnection obj = new Connnection();
                obj.conn.Open();
                obj.cmd = new SqlCommand("use master; RESTORE DATABASE School_System FROM DISK ='" + textBox2.Text + "' ", obj.conn);
                obj.cmd.ExecuteNonQuery();
                obj.conn.Close();
                MessageBox.Show("DATABASEKA WAA LASOO CELIYEY");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Dashboard().Show();
            this.Hide();
        }
    }
}
