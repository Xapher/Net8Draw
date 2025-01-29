using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET8Draw
{
    public partial class NewCanvasForm : Form
    {
        Form1 parent;
        int width = 512, height = 512;
        public NewCanvasForm(Form1 caller, int w, int h)
        {
            parent = caller;
            InitializeComponent();

            

            this.FormClosing += NewCanvasForm_FormClosing;
            widthNum.Value = w;
            heightNum.Value = h;

            this.ShowDialog();
        }


        private void NewCanvasForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            parent.closeForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.initNewCanvas((int)widthNum.Value, (int)heightNum.Value);
            Close();
        }
    }
}
