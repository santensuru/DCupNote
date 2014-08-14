using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCupNote
{
    partial class MainForm
    {
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
