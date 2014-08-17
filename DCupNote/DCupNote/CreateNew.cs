using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    public partial class CreateNew : Form
    {
        private DCupNote _dcn;
        private byte[] fileByte;
        private Binary fileBinary;

        public CreateNew()
        {
            InitializeComponent();
            _dcn = null;
        }

        public DCupNote GetDCupNote()
        {
            return _dcn;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(idTB.Text) ||
                    pictureBox1.Image == null)
                {
                    string message = "";

                    if (String.IsNullOrWhiteSpace(idTB.Text))
                        message += "The ID must be filled.\n";
                    if (pictureBox1.Image == null)
                        message += "The Image must be filled.";

                    MessageBox.Show(message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    DCupNoteDataClassesDataContext DDC = new DCupNoteDataClassesDataContext();
                    DCupNote dcupnote = (from p in DDC.DCupNotes
                                    where p.ID_DCupNote == idTB.Text
                                    select p).FirstOrDefault();

                    if (dcupnote != null && _dcn == null)
                        MessageBox.Show("The ID have been used by another data. Please use another ID.",
                            "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    else
                    {
                        if (_dcn == null)
                        {
                            _dcn = new DCupNote();
                            _dcn.ID_DCupNote = idTB.Text;
                        }

                        _dcn.Title = titleTB.Text;
                        _dcn.Notes_DCN = notesTB.Text;

                        if (pictureBox1.Image != null)
                        {
                            fileByte = ImageToByteArray(pictureBox1.Image);
                            fileBinary = new Binary(fileByte);
                            _dcn.Image = fileBinary;
                        }
                        else
                            _dcn.Image = null;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";

                if (ofd.ShowDialog() == DialogResult.OK && !String.IsNullOrWhiteSpace(ofd.FileName))
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void defaultBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(titleTB.Text))
            {
                MessageBox.Show("Please fill the Title first, please.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                DateTime date = DateTime.Today;
                idTB.Text = titleTB.Text + date.ToLongDateString();
                idTB.Text = idTB.Text.Replace(" ", "");
            }
        }


    }
}
