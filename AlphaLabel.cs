using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    public partial class AlphaLabel : Control
    {
        bool needsRedraw = true;
        Bitmap textBitmap;

        public byte Alpha { get; set; } = 128;

        string[] lines = { "alphaLabel" };
        public string[] Lines {
            get {
                needsRedraw = true;
                return lines;
            }
            set { lines = value; }
        }



        public override string Text
        {
            get
            {
                return string.Join("\n", Lines);
            }

            set
            {
                Lines = value.Split('\n');
            }
        }

        public AlphaLabel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.Opaque, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x20;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;

            var bitmap = getBitmap(pe.ClipRectangle);

            g.FillRectangle(new SolidBrush(Color.FromArgb(Alpha, BackColor)), pe.ClipRectangle);
            g.DrawImage(bitmap, Point.Empty);
        }

        private Bitmap getBitmap(Rectangle rect)
        {
            if (needsRedraw || textBitmap == null)
            {
                var bitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                var bmpTxt = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                var bmpSdw = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
                var gBmp = Graphics.FromImage(bitmap);
                var gTxt = Graphics.FromImage(bmpTxt);
                var gSdw = Graphics.FromImage(bmpSdw);

                var bTxt = new SolidBrush(ForeColor);
                var bSdw = new SolidBrush(Color.Black);


                gBmp.CompositingMode = CompositingMode.SourceOver;
                gBmp.CompositingQuality = CompositingQuality.HighQuality;
                gBmp.SmoothingMode = SmoothingMode.HighQuality;

                var items = Lines.ToList();

                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    string newItem = "";
                    while (true)
                    {
                        var stringSize = gTxt.MeasureString(item, Font);
                        if (stringSize.Width < Width)
                        {
                            if (!string.IsNullOrEmpty(newItem))
                                items.Insert(i + 1, "                  " + newItem);
                            break;
                        }
                        else
                        {
                            var c = item.Substring(item.Length - 1, 1);
                            item = item.Substring(0, item.Length - 1);
                            newItem = c + newItem;
                        }

                    }
                    var p = new Point(Padding.Left, Padding.Top + (i * 18));
                    gTxt.DrawString(item, Font, bTxt, p);
                    gSdw.DrawString(item, Font, bSdw, p);
                }

                var bmpSdw2 = bmpSdw.GetThumbnailImage(bmpSdw.Width / 2, bmpSdw.Height / 2, () => true, IntPtr.Zero);

                gBmp.DrawImage(bmpSdw2, rect, new Rectangle(Point.Empty, bmpSdw2.Size), GraphicsUnit.Pixel);
                gBmp.DrawImage(bmpSdw2, rect, new Rectangle(Point.Empty, bmpSdw2.Size), GraphicsUnit.Pixel);
                gBmp.DrawImage(bmpTxt, Point.Empty);

                textBitmap = bitmap;
                needsRedraw = false;
            }

            return textBitmap;
        }
    }
}
