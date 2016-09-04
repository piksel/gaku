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
    using TextSubItem = Tuple<string, Font, Brush>;

    public partial class AlphaLabel : Control
    {
        bool needsRedraw = true;
        Bitmap textBitmap;

        public byte Alpha { get; set; } = 128;

        public bool SimpleRichFormatting { get; set; } = true;

        public int WrapPadding { get; set; } = 1;
        bool fastTextDraw;

        public bool FastTextDraw
        {
            get
            {
                return fastTextDraw;
            }

            set
            {
                fastTextDraw = value;
                SetStyle(ControlStyles.Opaque, !value);
                needsRedraw = true;
                DoubleBuffered = value;
                Invalidate();
            }
        }

        string _wrapPadString;
        string WrapPadString { get
            {
                if (_wrapPadString == null)
                    _wrapPadString = new String(' ', WrapPadding);
                return _wrapPadString;
            }
        }


        Color _highlightColor = Color.FromArgb(255, 75, 168);
        [DefaultValue("255, 75, 168")]
        public Color HightlightColor {
            get {
                return _highlightColor;
            }
            set {
                _highlightColor = value;
                needsRedraw = true;
                Invalidate();
            }
        }

        Color _shadowColor = Color.FromArgb(255, 0, 0, 0);
        [DefaultValue("200, 0, 0, 0")]
        public Color ShadowColor
        {
            get
            {
                return _shadowColor;
            }
            set
            {
                _shadowColor = value;
                needsRedraw = true;
                Invalidate();
            }
        }

        string[] lines = { "alphaLabel" };
        public string[] Lines {
            get {
                return lines;
            }
            set {
                lines = value;
                needsRedraw = true;
                Invalidate();
            }
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
                if(!FastTextDraw)
                    cp.ExStyle = cp.ExStyle | 0x20;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (pe.ClipRectangle == Rectangle.Empty)
                return;
            var g = pe.Graphics;

            var bitmap = getBitmap(pe.ClipRectangle);

            if(!FastTextDraw)
                g.FillRectangle(new SolidBrush(Color.FromArgb(Alpha, BackColor)), pe.ClipRectangle);
            else
                g.FillRectangle(new SolidBrush(BackColor), pe.ClipRectangle);
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
                var bHgl = new SolidBrush(HightlightColor);
                var bSdw = new SolidBrush(ShadowColor);

                var sf = StringFormat.GenericTypographic;

                gTxt.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                gSdw.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

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
                                items.Insert(i + 1, WrapPadString + newItem);
                            break;
                        }
                        else
                        {
                            var c = item.Substring(item.Length - 1, 1);
                            item = item.Substring(0, item.Length - 1);
                            newItem = c + newItem;
                        }

                    }

                    //var em16a = gTxt.MeasureString(" ", Font, 100, StringFormat.GenericTypographic);
                    //var em16b = gTxt.MeasureString("  ", Font, 100, StringFormat.GenericTypographic);
                    //var em16 = em16b.Width - (em16b.Width - em16a.Width);

                    var subitems = new List<TextSubItem>();
                    var sicText = new StringBuilder();
                    var sicFont = Font;
                    var sicBrush = bTxt;
                    if (SimpleRichFormatting)
                    {
                        foreach (var c in item)
                        {
                            if (c == '[' || c == ']' || c == '*' || c == '_')
                            {
                                //sicText.Append(" ");
                                //if (sicText.Length > 0)
                                //{

                                subitems.Add(new TextSubItem(sicText.ToString(), sicFont, sicBrush));
                                sicText.Clear();
                                //}

                                if (c == '*') sicFont = new Font(sicFont, (sicFont.Bold ? (sicFont.Style & ~FontStyle.Bold) : (sicFont.Style | FontStyle.Bold)));
                                if (c == '_') sicFont = new Font(sicFont, (sicFont.Underline ? (sicFont.Style & ~FontStyle.Underline) : (sicFont.Style | FontStyle.Underline)));
                                if (c == '[') sicBrush = bHgl;
                                if (c == ']') sicBrush = bTxt;
                            }
                            else
                            {
                                sicText.Append(c);
                            }
                        }
                    }
                    else
                    {
                        sicText.Append(item);
                    }

                    subitems.Add(new TextSubItem(sicText.ToString(), sicFont, sicBrush));

                    var p = new Point(Padding.Left, Padding.Top + (i * 18));

                    foreach (var si in subitems)
                    {
                        var sis = gTxt.MeasureString(si.Item1 + "_", si.Item2, rect.Width, sf);
                        //gSdw.FillRectangle(Brushes.Lime, new Rectangle(p, sis.ToSize()));

                        gTxt.DrawString(si.Item1, si.Item2, si.Item3, p, sf);
                        if (!FastTextDraw)
                        {
                            gSdw.DrawString(si.Item1, si.Item2, bSdw, p, sf);
                        }
                        else
                        {
                            //gSdw.FillRectangle(Brushes.Black, new Rectangle(p, new Size((int)Math.Ceiling(sis.Width), (int)sis.Height)));
                        }

                        p.X += (int)Math.Round(sis.Width);
                    }



                }
                if (!FastTextDraw) {
                    var bmpSdw2 = bmpSdw.GetThumbnailImage(bmpSdw.Width / 2, bmpSdw.Height / 2, () => true, IntPtr.Zero);
                    var bmpSdw4 = bmpSdw.GetThumbnailImage(bmpSdw.Width / 4, bmpSdw.Height / 4, () => true, IntPtr.Zero);

                    gBmp.DrawImage(bmpSdw2, rect, new Rectangle(Point.Empty, bmpSdw2.Size), GraphicsUnit.Pixel);
                    gBmp.DrawImage(bmpSdw2, rect, new Rectangle(Point.Empty, bmpSdw2.Size), GraphicsUnit.Pixel);
                    gBmp.DrawImage(bmpSdw4, rect, new Rectangle(Point.Empty, bmpSdw4.Size), GraphicsUnit.Pixel);
                    gBmp.DrawImage(bmpSdw4, rect, new Rectangle(Point.Empty, bmpSdw4.Size), GraphicsUnit.Pixel);
                }
                else
                {
                    gBmp.DrawImage(bmpSdw, Point.Empty);
                }
                gBmp.DrawImage(bmpTxt, Point.Empty);

                textBitmap = bitmap;
                needsRedraw = false;
            }

            return textBitmap;
        }
    }
}
