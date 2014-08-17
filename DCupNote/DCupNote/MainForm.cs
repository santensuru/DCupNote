using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    public partial class MainForm : Form
    {
        DCupNoteDataClassesDataContext DDC;

        class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
        }

        private Graphics gObject;
        private Stack<Line> lines = new Stack<Line>();

        public MainForm()
        {
            InitializeComponent();
            SetLayout();
            DDC = new DCupNoteDataClassesDataContext();
            //Dock = DockStyle.Fill;
            //DoubleBuffered = true;
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
            lines.Push(new Line { Start = e.Location });
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (var line in lines)
            {
                gObject = pictureBox1.CreateGraphics();
                gObject.DrawLine(Pens.Black, line.Start, line.End);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //foreach (var line in lines)
            //{
            //    e.Graphics.DrawLine(Pens.Black, line.Start, line.End);
            //}
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lines.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox1.Invalidate();
                lines.Peek().End = e.Location;
                foreach (var line in lines)
                {
                    gObject = pictureBox1.CreateGraphics();
                    gObject.DrawLine(Pens.Black, line.Start, line.End);
                }

            }
        }

        

    }
}
