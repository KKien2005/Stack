using CLIPBOARD_CLASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fCUT
{
    public partial class fCUT : Form
    {
        public fCUT()
        {
            InitializeComponent();
        }

        private CLIPBOARDRB.ClipboardRB<object> cb = new CLIPBOARDRB.ClipboardRB<object>();

        private void button1_Click(object sender, EventArgs e) // Cut
        {
            cb.Add(textBox1.Text, textBox1.SelectedText);
        }

        private void button2_Click(object sender, EventArgs e) // Paste
        {
            textBox2.Text = cb.Paste(textBox2.Text);
            textBox1.Text = cb.ClearInput(textBox1.Text);
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e) // Reset
        {
            textBox1.Clear();
            textBox2.Clear();
            cb.ClearStack();
        }

        private void button4_Click(object sender, EventArgs e) // Close
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void fCUT_Load(object sender, EventArgs e)
        {
        }
    }
}
