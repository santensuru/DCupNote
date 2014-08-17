using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    public partial class ViewLibraryDCN : Form
    {
        private DCupNoteDataClassesDataContext DDC;
        private DCupNote _dcn;

        public ViewLibraryDCN(DCupNoteDataClassesDataContext _DDC)
        {
            InitializeComponent();
            DDC = _DDC;
            _dcn = null;
            UpdateDCupNoteDGV();
        }

        public DCupNote GetDCupNote()
        {
            return _dcn;
        }

        private void UpdateDCupNoteDGV()
        {
            dCupNoteDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dCupNoteDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dCupNoteDGV.EnableHeadersVisualStyles = false;
            dCupNoteDGV.ColumnCount = 3;
            dCupNoteDGV.Columns[0].HeaderText = "ID";
            dCupNoteDGV.Columns[1].HeaderText = "Title";
            dCupNoteDGV.Columns[2].HeaderText = "Notes";

            DataGridViewImageColumn img = new DataGridViewImageColumn();
            dCupNoteDGV.Columns.Add(img);
            img.HeaderText = "Image";

            List<DCupNote> listDCN = DDC.DCupNotes.ToList();

            dCupNoteDGV.Rows.Clear();
            foreach (DCupNote dcn in listDCN)
            {
                Image image;
                if (dcn.Image != null)
                {
                    image = ByteArrayToImage(dcn.Image.ToArray());
                    Size newSize = new System.Drawing.Size();
                    newSize.Height = newSize.Width = 200;
                    image = resizeImage(image, newSize);
                }
                else
                    image = null;

                dCupNoteDGV.Rows.Add(dcn.ID_DCupNote, dcn.Title, dcn.Notes_DCN, image);
            }
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dCupNoteDGV.CurrentRow != null)
                {
                    string selectedID = (string)dCupNoteDGV.CurrentRow.Cells[0].Value;
                    _dcn = (from d in DDC.DCupNotes
                            where d.ID_DCupNote == selectedID
                            select d).FirstOrDefault();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
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
                if (dCupNoteDGV.CurrentRow != null)
                {
                    string selectedID = (string)dCupNoteDGV.CurrentRow.Cells[0].Value;

                    if (MessageBox.Show("Do you want to delete this D'Cup Note?", "Question [Delete]",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        List<TagNote> listTN = (from tn in DDC.TagNotes
                                                where tn.ID_DCupNote == selectedID
                                                select tn).ToList();

                        if (listTN.Count > 0)
                            DDC.TagNotes.DeleteAllOnSubmit(listTN);

                        _dcn = (from d in DDC.DCupNotes
                                        where d.ID_DCupNote == selectedID
                                        select d).FirstOrDefault();

                        DDC.DCupNotes.DeleteOnSubmit(_dcn);
                        DDC.SubmitChanges();
                        UpdateDCupNoteDGV();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
