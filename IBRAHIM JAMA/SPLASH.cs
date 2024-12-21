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
    public partial class SPLASH : Form
    {
        public SPLASH()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;
                label2.Text = progressBar1.Value.ToString();
            }
            else
            {
                new Form1().Show();
                this.Hide();
                timer1.Stop();
            }
        }
    }
}
