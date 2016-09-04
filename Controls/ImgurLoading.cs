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
using Imgur.API.Models;
using System.Diagnostics;

namespace Gaku
{
    public partial class ImgurLoading : Control
    {
        private GifImage gifImage;
        private Image currentFrame;
        private Timer timer;

        int _speed = 80;
        private bool redrawOutline = true;
        int padding = 3;
        int padding2 = 6;

        [DefaultValue(typeof(Color), "20, 20, 20")]
        public override Color BackColor { get; set; } = Color.FromArgb(20, 20, 20);
        private Pen outlinePen;

        public int Speed { get
            {
                return _speed;
            }
            set
            {
                _speed = (value < 95) ? value : 95;
                if (timer != null)
                    timer.Interval = 100 - _speed;
            }
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

        public IImage ImgurImage { get; internal set; }

        bool _done = false;
        public bool Done { get
            {
                return _done;
            }
            set
            {
                _done = value;
                Cursor = _done ? Cursors.Hand : Cursors.Default;
                if (_done)
                {
                    timer.Stop();
                    Invalidate();
                }
                else
                {
                    timer.Start();
                }
            }
        }

        public ImgurLoading()
        {
            InitializeComponent();

            outlinePen = new Pen(BackColor, padding);
            SetStyle(ControlStyles.Opaque, true);

            gifImage = new GifImage(Properties.Resources.pKopwXp);
            currentFrame = gifImage.GetNextFrame();

            VisibleChanged += ImgurLoading_VisibleChanged;
            Click += ImgurLoading_Click;
            
            timer = new Timer()
            {
                Interval = 100 - _speed,
            };
            timer.Tick += Timer_Tick;
            if(Visible && !Done)
                timer.Start();
            
        }

        private void ImgurLoading_Click(object sender, EventArgs e)
        {
            if (!_done) return;

            Process.Start(ImgurImage.Link);
        }

        private void ImgurLoading_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && !Done)
                timer.Start();
            else
                timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentFrame = gifImage.GetNextFrame();
            redrawOutline = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var cr = pe.ClipRectangle;

            var circleBounds = new Rectangle(
                new Point(cr.X + padding, cr.Y + padding), 
                new Size(cr.Width - padding2, cr.Height - padding2)
            );

            if (redrawOutline)
            {
                // Draw a thin circle around the outside of the animated circle since it's aliased
                pe.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                pe.Graphics.CompositingMode = CompositingMode.SourceOver;
                pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                pe.Graphics.DrawEllipse(outlinePen, circleBounds);
            }
            // This is normally set so that outside invalidations will draw the outline again, but not if it's triggered from the timer
            else redrawOutline = true; 

            if (_done)
            {
                // Draw the check icon instead of the animation
                pe.Graphics.FillEllipse(new SolidBrush(BackColor), circleBounds);
                pe.Graphics.DrawImage(Properties.Resources.upload_done, circleBounds);
            }
            else
            {
                // Create a clipping region, so that the rectangular image does not draw outside of the circle
                var gp = new GraphicsPath();
                gp.AddEllipse(circleBounds);
                pe.Graphics.Clip = new Region(gp);

                pe.Graphics.DrawImage(currentFrame, circleBounds);
            }
        }
    }
}
