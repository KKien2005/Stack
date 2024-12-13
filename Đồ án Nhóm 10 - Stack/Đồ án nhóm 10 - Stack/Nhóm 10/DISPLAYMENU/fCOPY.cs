using CLIPBOARD_CLASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fCOPY
{
    public partial class fCOPY : Form
    {
        private Stack<(string, string, object[])> undoStack = new Stack<(string, string, object[])>();

        public fCOPY()
        {
            InitializeComponent();
        }

        private CLIPBOARDRB.ClipboardRB<object> cb = new CLIPBOARDRB.ClipboardRB<object>();

        private void fCOPY_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void fCOPY_Shown(object sender, EventArgs e)
        {
            // Đảm bảo khi form hiển thị, con trỏ sẽ đặt vào textBox1
            textBox1.Focus();
        }

        private void fCOPY_KeyDown(object sender, EventArgs e)
        {
            // Đảm bảo khi form hiển thị, con trỏ sẽ đặt vào textBox1
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e) // Copy
        {
            undoStack.Push((textBox1.Text, textBox2.Text, cb.GetStackState()));
            cb.Add(textBox1.Text, textBox1.SelectedText);
            MessageBox.Show("Phần tử đã được thêm vào ngăn xếp Stack");
        }

        private void button2_Click(object sender, EventArgs e) // Paste
        {
            undoStack.Push((textBox1.Text, textBox2.Text, cb.GetStackState()));
            textBox2.Text = cb.Paste(textBox2.Text);
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e) // Reset
        {
            undoStack.Push((textBox1.Text, textBox2.Text, cb.GetStackState()));
            textBox1.Clear();
            textBox2.Clear();
            cb.ClearStack();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e) // Close
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                MessageBox.Show("Đã hoàn tác hành động");
                var previousState = undoStack.Pop(); // Lấy trạng thái trước đó
                textBox1.Text = previousState.Item1;
                textBox2.Text = previousState.Item2;
                cb.RestoreStackState(previousState.Item3);
            }
            else
            {
                MessageBox.Show("Không có hành động nào để hoàn tác!");
            }
        }

        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                button5.PerformClick(); // Thực hiện thao tác Undo
            }
        }

        
    }
}
