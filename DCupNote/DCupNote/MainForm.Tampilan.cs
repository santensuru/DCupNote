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
        private DCupNote dcnOpen;

        private void SetAfterNewOrOpen(string id_dcupnote)
        {
            try
            {
                dcnOpen = (from dcn in DDC.DCupNotes
                                    where dcn.ID_DCupNote == id_dcupnote
                                    select dcn).FirstOrDefault();

                if (dcnOpen.Image != null)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = ByteArrayToImage(dcnOpen.Image.ToArray());
                }

                editBtn.Enabled = true;
                titleTB.Text = dcnOpen.Title;
                notesTB.Text = dcnOpen.Notes_DCN;

                UpdateNotesFLP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateNotesFLP()
        {
            List<TagNote> ListTN = (from tn in DDC.TagNotes
                                    where tn.ID_DCupNote == dcnOpen.ID_DCupNote
                                    select tn).ToList();

            noteFlowLayoutPanel.Controls.Clear();
            foreach (TagNote TN in ListTN)
            {
                FlowLayoutPanel newPanel = new FlowLayoutPanel();
                FlowLayoutPanel newPanel2 = new FlowLayoutPanel();
                Label location = new Label();
                TextBox noteTB = new TextBox();
                Button delBtn = new Button();

                noteTB.Size = new System.Drawing.Size(noteFlowLayoutPanel.Width - 50, 20);
                noteTB.Multiline = true;
                noteTB.Text = TN.Notes_TN;
                noteTB.TextChanged += new System.EventHandler(noteTB_TextChanged);
                noteTB.Name = TN.ID_TagNote;

                location.Text = "( " + TN.LocationX.ToString() + "," + TN.LocationY.ToString() + " )";
                location.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
                location.Size = new System.Drawing.Size(noteFlowLayoutPanel.Width - 73, 23);

                delBtn.Text = "X";
                delBtn.FlatStyle = FlatStyle.Popup;
                delBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                delBtn.ForeColor = Color.Red;
                delBtn.Margin = new System.Windows.Forms.Padding(0);
                delBtn.Size = new System.Drawing.Size(23, 23);
                delBtn.Click += new System.EventHandler(delBtn_Click);
                delBtn.Name = TN.ID_TagNote;

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


    }
}
