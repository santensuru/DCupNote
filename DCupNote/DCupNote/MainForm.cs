using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    public partial class MainForm : Form
    {
        private int startX;
        private int startY;
        private int endX;
        private int endY;

        public MainForm()
        {
            InitializeComponent();
            SetLayout();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X.ToString() + "  " + e.Y.ToString());
            //int x = e.X;
            //int y = e.Y;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X.ToString() + "  " + e.Y.ToString(), "Down");
            startX = e.X;
            startY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X.ToString() + "  " + e.Y.ToString(), "Up");
            endX = e.X;
            endY = e.Y;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(0, 0, 0, 0));
            e.Graphics.DrawLine(pen, startX, startY, endX, endY);
            MessageBox.Show(startX.ToString() + startY.ToString() + endX.ToString() + endY.ToString());
        }

    }
}
