using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBRAHIM_JAMA
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void sTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Students().Show();
            this.Hide();
        }

        private void uSERSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new Users().Show();
            this.Hide();
        }

        private void sTUDENTREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Student_Report_View().Show();
            this.Hide();
        }

        private void bACKUPRESTOREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BACKUP_RESTORE().Show();
            this.Hide();
        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Class().Show();
            this.Hide();
        }

        private void cALCULATERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CALC.EXE");
        }

        private void eXCALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel.EXE");
        }

        private void wORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword.EXE");
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void aPPSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
