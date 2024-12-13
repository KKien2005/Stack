using fCOPY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DISPLAYMENU
{
    public partial class DISPLAYMENU : Form
    {
        public DISPLAYMENU()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fCOPY.fCOPY fcopy = new fCOPY.fCOPY();
            DISPLAYMENU dISPLAYMENU = this;
            dISPLAYMENU.Hide();
            fcopy.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fCUT.fCUT fcut = new fCUT.fCUT();
            DISPLAYMENU dISPLAYMENU = this;
            dISPLAYMENU.Hide();
            fcut.ShowDialog();
            this.Show();
        }

        private void DISPLAYMENU_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
