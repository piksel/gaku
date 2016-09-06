using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    partial class FormGaku
    {
        private void imageInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imageFile)) return;

            ToggleImageInformation();
        }

        private void setSizeToImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings.DisplayMode = DisplayMode.AutoFit;
            imageSettings.FrameSize = getAutoSize();
            setSize(imageSettings.FrameSize);
            updateDisplayMode();
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pbMain.Image);
        }

        private void pxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tsmi = sender as ToolStripMenuItem;
            imageSettings.BorderWidth = int.Parse(tsmi.Tag as string);

            pxToolStripMenuItem.Checked = tsmi == pxToolStripMenuItem;
            pxToolStripMenuItem1.Checked = tsmi == pxToolStripMenuItem1;
            pxToolStripMenuItem2.Checked = tsmi == pxToolStripMenuItem2;
            pxToolStripMenuItem3.Checked = tsmi == pxToolStripMenuItem3;
            pxToolStripMenuItem4.Checked = tsmi == pxToolStripMenuItem4;
            pxToolStripMenuItem5.Checked = tsmi == pxToolStripMenuItem5;

            updateBorderStyle();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setBorderColor(Color.Black);
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setBorderColor(Color.White);
        }

        private void customToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.Color = imageSettings.BorderColor;
            if (cd.ShowDialog() == DialogResult.OK)
                setBorderColor(cd.Color);
        }


        private void bClose_MouseEnter(object sender, EventArgs e)
        {
            bClose.ForeColor = Color.Black;
        }

        private void bClose_MouseLeave(object sender, EventArgs e)
        {
            bClose.ForeColor = Color.White;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormGaku_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(imageSettings.FileName))
                imageSettings.Save();
            settings.Save();
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings.BorderStyle = BorderStyle.None;
            updateBorderStyle();
        }

        private void thinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings.BorderStyle = BorderStyle.Thin;
            updateBorderStyle();
        }

        private void resizableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings.BorderStyle = BorderStyle.Resizable;
            updateBorderStyle();
        }

        private void toolboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings.BorderStyle = BorderStyle.Toolbox;
            updateBorderStyle();
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageSettings.BorderStyle = BorderStyle.Custom;
            updateBorderStyle();
        }

    }
}
