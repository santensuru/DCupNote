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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                FlowLayoutPanel newPanel = new FlowLayoutPanel();
                Label location = new Label();
                TextBox noteTB = new TextBox();
                noteTB.Size = new System.Drawing.Size(noteFlowLayoutPanel.Width - 50, 20);
                noteTB.Multiline = true;
                location.AutoSize = true;
                location.Text = "( " + e.X.ToString() + "," + e.Y.ToString() + " )";
                newPanel.AutoSize = true;
                newPanel.FlowDirection = FlowDirection.TopDown;
                newPanel.Padding = new System.Windows.Forms.Padding(5);
                newPanel.Controls.Add(location);
                newPanel.Controls.Add(noteTB);
                newPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                newPanel.Width = noteFlowLayoutPanel.Width - 20;
                noteFlowLayoutPanel.Controls.Add(newPanel);
            }
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
            //Pen pen = new Pen(Color.FromArgb(0, 0, 0, 0));
            //e.Graphics.DrawLine(pen, startX, startY, endX, endY);
            //MessageBox.Show(startX.ToString() + startY.ToString() + endX.ToString() + endY.ToString());
        }

        

        

    }
}
