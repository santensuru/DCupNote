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
        TagNote tnOpen;

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
                FlowLayoutPanel newPanel2 = new FlowLayoutPanel();
                Label location = new Label();
                TextBox noteTB = new TextBox();
                Button delBtn = new Button();

                noteTB.Size = new System.Drawing.Size(noteFlowLayoutPanel.Width - 50, 20);
                noteTB.Multiline = true;
                noteTB.TextChanged += new System.EventHandler(noteTB_TextChanged);

                location.Text = "( " + e.X.ToString() + "," + e.Y.ToString() + " )";
                location.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
                location.Size = new System.Drawing.Size(noteFlowLayoutPanel.Width - 73, 23);

                delBtn.Text = "X";
                delBtn.FlatStyle = FlatStyle.Popup;
                delBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                delBtn.ForeColor = Color.Red;
                delBtn.Margin = new System.Windows.Forms.Padding(0);
                delBtn.Padding = new System.Windows.Forms.Padding(0);
                delBtn.Size = new System.Drawing.Size(23, 23);
                delBtn.Click += new System.EventHandler(delBtn_Click);

                newPanel2.Size = new System.Drawing.Size(noteFlowLayoutPanel.Width - 50, 23);
                newPanel2.FlowDirection = FlowDirection.LeftToRight;

                newPanel2.Controls.Add(location);
                newPanel2.Controls.Add(delBtn);

                newPanel.AutoSize = true;
                newPanel.FlowDirection = FlowDirection.TopDown;
                newPanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
                
                newPanel.Controls.Add(newPanel2);
                newPanel.Controls.Add(noteTB);
                newPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                noteFlowLayoutPanel.Controls.Add(newPanel);
                //MessageBox.Show(newPanel.Width.ToString());

                DateTime date = DateTime.Now;
                tnOpen = new TagNote();
                tnOpen.ID_TagNote = ("TN" + date.ToShortDateString() + "_" + date.ToLongTimeString()).Replace("/","-").Replace(":","-");
                tnOpen.ID_DCupNote = dcnOpen.ID_DCupNote;
                tnOpen.LocationX = e.X;
                tnOpen.LocationY = e.Y;
                DDC.TagNotes.InsertOnSubmit(tnOpen);
                DDC.SubmitChanges();

                delBtn.Name = tnOpen.ID_TagNote;
                noteTB.Name = tnOpen.ID_TagNote;
            }
        }

        private void noteTB_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tnOpen = (from tn in DDC.TagNotes
                      where tn.ID_TagNote == tb.Name
                      select tn).FirstOrDefault();

            tnOpen.Notes_TN = tb.Text;
            DDC.SubmitChanges();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            tnOpen = (from tn in DDC.TagNotes
                      where tn.ID_TagNote == b.Name
                      select tn).FirstOrDefault();

            DDC.TagNotes.DeleteOnSubmit(tnOpen);
            DDC.SubmitChanges();

            UpdateNotesFLP();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                lines.Push(new Line { Start = e.Location });
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                foreach (var line in lines)
                {
                    gObject = pictureBox1.CreateGraphics();
                    gObject.DrawLine(Pens.Black, line.Start, line.End);
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                foreach (var line in lines)
                {
                    e.Graphics.DrawLine(Pens.Black, line.Start, line.End);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (lines.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left && pictureBox1.Image != null)
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (editBtn.Text == "Edit")
            {
                editBtn.Text = "Save";
                titleTB.ReadOnly = false;
                notesTB.ReadOnly = false;
            }
            else if (editBtn.Text == "Save")
            {
                dcnOpen.Title = titleTB.Text;
                dcnOpen.Notes_DCN = notesTB.Text;
                DDC.SubmitChanges();
                editBtn.Text = "Edit";
                titleTB.ReadOnly = true;
                notesTB.ReadOnly = true;
            }
        }

    }
}
