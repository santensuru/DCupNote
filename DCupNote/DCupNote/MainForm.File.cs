﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    partial class MainForm
    {
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrWhiteSpace(ofd.FileName))
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                using (var nya = new System.IO.FileStream(ofd.FileName.ToString(), System.IO.FileMode.Open))
                {
                    var bmp = new Bitmap(nya);
                    pictureBox1.Image = (Bitmap)bmp.Clone() as Bitmap;
                    bmp.Dispose();
                    nya.Dispose();
                }

                pictureBox1.Visible = true;
                saveAsToolStripMenuItem.Visible = true;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";


            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                string path = sfd.FileName.ToString();
                Bitmap default_image = new Bitmap(pictureBox1.Image);
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                    {
                        default_image.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                pictureBox1.Image = default_image;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            saveAsToolStripMenuItem.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
