using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    using ModKeys = System.Windows.Input.ModifierKeys;
    using Keyboard = System.Windows.Input.Keyboard;
    using System.Drawing;

    public delegate void SizeHandlerResizedEventHandler(object sender, EventArgs e);

    public class SizeHandler
    {
        MoveMode moveMode = MoveMode.None;
        SizeMode sizeMode;

        Point moveOrigin;
        Rectangle rectOrigin;
        Point correction;

        private Form form;

        double zoom = 1;

        int hysterisisCooldown = 0;

        bool localDelta = false;
        private readonly int WHEEL_DELTA = 120;

        public ImageSettings ImageSettings { get; set; }

        PictureBox pbMain;
        private GeneralSettings settings;

        Image image;

        public event SizeHandlerResizedEventHandler Resized;

        protected virtual void OnResized(EventArgs e)
        {
            if (Resized != null)
                Resized(this, e);
        }


        public SizeHandler(Form form, ImageSettings imageSettings, PictureBox pbMain, GeneralSettings settings): this(form, imageSettings, pbMain.Image, settings)
        {
            this.pbMain = pbMain;
        }

        public SizeHandler(Form form, ImageSettings imageSettings, Image image, GeneralSettings settings)
        {
            this.form = form;
            ImageSettings = imageSettings;
            this.image = image;
            this.settings = settings;
        }

        public void HandleMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            moveOrigin = localDelta ? (sender as Control).PointToClient(e.Location) : e.Location;
            rectOrigin = new Rectangle(form.Location, form.Size);

            if (Keyboard.Modifiers.HasFlag(ModKeys.Control) || e.Button == MouseButtons.Middle)
            {
                if (ImageSettings.DisplayMode == DisplayMode.PanMoveCrop)
                    moveMode = MoveMode.Image;
            }
            else if (Keyboard.Modifiers.HasFlag(ModKeys.Alt))
            {
                moveMode = MoveMode.Size;
                sizeMode = SizeMode.None;

                var localPos = form.PointToClient(e.Location);

                sizeMode |= (localPos.X > form.Width / 2) ? SizeMode.Right : SizeMode.Left;
                sizeMode |= (localPos.Y > form.Height / 2) ? SizeMode.Bottom : SizeMode.Top;

                sizeMode = SizeMode.BottomRight;
            }
            else if (Keyboard.Modifiers.HasFlag(ModKeys.Shift))
            {
                if (ImageSettings.DisplayMode == DisplayMode.PanMoveCrop)
                    moveMode = MoveMode.Zoom;
            }
            else
            {
                moveMode = MoveMode.Window;
            }

        }

        public void HandleMouseWheel(object sender, MouseEventArgs e)
        {
            UpdateZoom(e.Delta / WHEEL_DELTA);
        }

        public void UpdateZoom(int delta = 0, bool initial = false)
        {
            if (ImageSettings.DisplayMode == DisplayMode.AutoFit) return;
            if(initial) zoom = ImageSettings.Zoom;

            var oldZoom = zoom;
            while (delta != 0)
            {
                if (delta > 0)
                {
                    zoom *= 1.1;
                    delta--;
                }
                else
                {
                    zoom *= 0.9;
                    delta++;
                }
            }
            if ((oldZoom > 1 && zoom < 1) ||
                (oldZoom < 1 && zoom > 1)
            )
            {
                zoom = 1;
                pbMain.SizeMode = PictureBoxSizeMode.Normal;
            }
            else
            {
                pbMain.SizeMode = PictureBoxSizeMode.Zoom;

            }

            var oldWidth = pbMain.Width;
            var oldHeight = pbMain.Height;

            pbMain.Width = Math.Max((int)(zoom * image.Width), 20);
            pbMain.Height = Math.Max((int)(zoom * image.Height), 20);

            if (!initial)
            {
                var diffX = pbMain.Width - oldWidth;
                var diffY = pbMain.Height - oldHeight;

                pbMain.Left = pbMain.Left - (diffX / 2);
                pbMain.Top = pbMain.Top - (diffY / 2);
            }

            ConstrainCanvas();

            OnResized(EventArgs.Empty);
        }

        public void HandleMouseMove(object sender, MouseEventArgs e)
        {
            var location = localDelta ? (sender as Control).PointToClient(e.Location) : e.Location;
            var deltaX = moveOrigin.X - location.X;
            var deltaY = moveOrigin.Y - location.Y;

            if (moveMode == MoveMode.Image)
            {
                if (pbMain == null) return;

                var newX = pbMain.Left - deltaX;
                var newY = pbMain.Top - deltaY;

                pbMain.Left = newX;
                pbMain.Top = newY;

                ConstrainCanvas();

            }
            else if (moveMode == MoveMode.Window)
            {
                form.Left -= deltaX;
                form.Top -= deltaY;
            }
            else if (moveMode == MoveMode.Size)
            {

                if (hysterisisCooldown > 0)
                {
                    hysterisisCooldown--;
                    return;
                }
                hysterisisCooldown = 3;

                if (sizeMode.HasFlag(SizeMode.Left))
                {
                    deltaX = 0 - deltaX;
                    //Left += deltaX;
                }
                if (sizeMode.HasFlag(SizeMode.Top))
                {
                    deltaY = 0 - deltaY;
                    //Top += deltaY;

                }

                var newWidth = rectOrigin.Width - deltaX;
                var newHeight = rectOrigin.Height - deltaY;

                if (newWidth < 10) newWidth = 10;
                if (newHeight < 10) newHeight = 10;

                if (Keyboard.Modifiers.HasFlag(ModKeys.Shift) ^ settings.KeepAspectRatio)
                {
                    double scale = ((double)newHeight + (float)ImageSettings.Padding) / image.Height;
                    newWidth = (int)((scale * image.Width) - (float)ImageSettings.Padding * 2);
                }

                form.Width = newWidth;
                form.Height = newHeight;

                if (sizeMode.HasFlag(SizeMode.Left))
                {
                    //deltaX = (int) (deltaX * 1.5);

                    //Left = rectOrigin.Left + (deltaX*2);
                    correction.X = deltaX;

                }

                OnResized(EventArgs.Empty);
            }
        }

        public void HandleMouseUp(object sender, MouseEventArgs e)
        {
            moveMode = MoveMode.None;

            if (ImageSettings == null) return;

            ImageSettings.FrameSize = form.Size;
            ImageSettings.Position = form.Location;
            ImageSettings.ImageOffset = pbMain != null ? pbMain.Location : ImageSettings.ImageOffset;
            ImageSettings.Zoom = zoom;

            ImageSettings.Save();
        }

        public void ConstrainCanvas()
        {
            var minSize = 20;

            var newX = pbMain.Left;
            var newY = pbMain.Top;

            if (pbMain.Width > form.Width)
            {
                var minX = form.Width - pbMain.Width;
                if (newX > 0) newX = 0;
                if (newX < minX) newX = minX;
            }
            else
            {
                newX = Math.Min(newX, form.Width - minSize);
                newX = Math.Max(newX, minSize - pbMain.Width);
            }

            if (pbMain.Height > form.Height)
            {
                var minY = form.Height - pbMain.Height;
                if (newY > 0) newY = 0;
                if (newY < minY) newY = minY;
            }
            else
            {
                newY = Math.Min(newY, form.Height - minSize);
                newY = Math.Max(newY, minSize - pbMain.Height);
            }

            pbMain.Left = newX;
            pbMain.Top = newY;
        }
    }
}
