using System;
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

namespace Gaku
{
    public partial class FormImageInfo : Form
    {
        private string imageFile;

        private void FormImageInfo_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormImageInfo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormImageInfo_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
