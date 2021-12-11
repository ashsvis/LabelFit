using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelFit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Resize(object sender, EventArgs e)
        {
            CalcFontSize(label1);
        }

        private void CalcFontSize(Label label)
        {
            IntPtr hwnd = this.Handle;
            using (Graphics g = Graphics.FromHwnd(hwnd))
            {
                var size = new SizeF();
                label.Font = new Font(label.Font.FontFamily, 8f);
                while (size.Width < label.ClientSize.Width && size.Height < label.ClientSize.Height)
                {
                    label.Font = new Font(label.Font.FontFamily, label.Font.Size + 1f);
                    size = g.MeasureString(label.Text, label.Font);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            label1.Text = btn.Text;
            CalcFontSize(label1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CalcFontSize(label1);
        }
    }
}
