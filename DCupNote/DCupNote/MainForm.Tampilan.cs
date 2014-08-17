using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    partial class MainForm
    {
        private void SetAfterNewOrOpen(string id_dcupnote)
        {
            try
            {
                DCupNote dcnOpen = (from dcn in DDC.DCupNotes
                                    where dcn.ID_DCupNote == id_dcupnote
                                    select dcn).FirstOrDefault();

                if (dcnOpen.Image != null)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = ByteArrayToImage(dcnOpen.Image.ToArray());
                    saveToolStripMenuItem.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Image ByteArrayToImage(byte[] bArray)
        {
            var Stream = new MemoryStream(bArray);
            return Image.FromStream(Stream);
        }

        private void SetLayout()
        {
            //panel2.Width = pictureBox1.Width = (int)(this.Width - 22) * 7 / 10;
            //panel1.Left = pictureBox1.Width + 16;
            //panel1.Width = (int)(this.Width - 22) * 2 / 10;
            //MessageBox.Show(pictureBox1.Width.ToString() + "  " +
            //    panel1.Width.ToString() + "  " +
            //    panel1.Left.ToString() + "  " +
            //    this.Width.ToString());
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            SetLayout();
        }

        ////...
        //private Image lastImage;
        //private Brush eraserBrush;
        ////...

        //// your standard paint method
        //private void My_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        //{
        //    if (something_has_changed_like_the_form_has_been_resi zed)
        //    {
        //        // we may need to redraw everything...
        //        Rectangle rect = this.GetDrawingRectangle();
        //        this.lastImage = new Bitmap(rect.Width, rect.Height);
        //        Graphics gx = Graphics.FromImage(this.lastImage);
        //        gx.Clear(this.BackColor);

        //        // draw the normal, erased state
        //        // ...
        //        // draw all of the elements that should be drawn...
        //        gx.Dispose();
        //        this.eraserBrush = new TextureBrush(this.lastImage);
        //    }

        //    // all of our lines, pictures, etc. are already stored
        //    // inside lastImage, so we don't need to do anything here.

        //    // let's say we kept track of some coordinates for a line,
        //    // and also kept track of whether or not we need to do
        //    // some erasing
        //    if (bLineNeedsErasing)
        //    {
        //        // by drawing to this Graphics object, we're updating the
        //        // bitmap image.
        //        Graphics imageGraphics = Graphics.FromImage(this.lastImage);

        //        // assuming the first line was drawn with a width of 1 (float)
        //        Pen p = new Pen(this.eraserBrush, 1F);

        //        // assuming we kept track of a couple System.Drawing.PointF
        //        // points representing the ends of the line
        //        imageGraphics.DrawLine(p, this.linePoint1, this.linePoint2);
        //        imageGraphics.Dispose();
        //    }

        //    Graphics g = e.Graphics;
        //    g.DrawImageUnscaled(this.lastImage,0,0);
        //    }

            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.DoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

    }
}
