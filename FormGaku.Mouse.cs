﻿using System;
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

    partial class FormGaku
    {
        private void global_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            moveOrigin = localDelta ? (sender as Control).PointToClient(e.Location) : e.Location;
            rectOrigin = new Rectangle(Location, Size);

            if (Keyboard.Modifiers.HasFlag(ModKeys.Control))
            {
                if (imageSettings.DisplayMode == DisplayMode.PanMoveCrop)
                    moveMode = MoveMode.Image;
            }
            else if (Keyboard.Modifiers.HasFlag(ModKeys.Alt))
            {
                moveMode = MoveMode.Size;
                sizeMode = SizeMode.None;

                var localPos = PointToClient(e.Location);

                sizeMode |= (localPos.X > Width / 2) ? SizeMode.Right : SizeMode.Left;
                sizeMode |= (localPos.Y > Height / 2) ? SizeMode.Bottom : SizeMode.Top;

                sizeMode = SizeMode.BottomRight;
            }
            else if (Keyboard.Modifiers.HasFlag(ModKeys.Shift))
            {
                if (imageSettings.DisplayMode == DisplayMode.PanMoveCrop)
                    moveMode = MoveMode.Zoom;
            }
            else
            {
                moveMode = MoveMode.Window;
            }

        }

        private void global_MouseWheel(object sender, MouseEventArgs e)
        {
            updateZoom(e.Delta / WHEEL_DELTA);
        }

        private void global_MouseMove(object sender, MouseEventArgs e)
        {
            var location = localDelta ? (sender as Control).PointToClient(e.Location) : e.Location;
            var deltaX = moveOrigin.X - location.X;
            var deltaY = moveOrigin.Y - location.Y;

            if (moveMode == MoveMode.Image)
            {
                var newX = pbMain.Left - deltaX;
                var newY = pbMain.Top - deltaY;

                if (newX > 0) newX = 0;
                if (newY > 0) newY = 0;

                pbMain.Left = newX;
                pbMain.Top = newY;

            }
            else if (moveMode == MoveMode.Window)
            {
                Left -= deltaX;
                Top -= deltaY;
            }
            else if (moveMode == MoveMode.Size)
            {
                if (Keyboard.Modifiers.HasFlag(ModKeys.Shift))
                {
                    //var deltaCombined = ((deltaX + deltaY) / 2) * (Width + Height);
                    //deltaX = deltaCombined / Width;
                    //deltaY = deltaCombined / Height;
                }

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

                if (Keyboard.Modifiers.HasFlag(ModKeys.Shift))
                {
                    double scale = ((double)newHeight + (float)imageSettings.Padding) / pbMain.Image.Height;
                    newWidth = (int)((scale * pbMain.Image.Width) - (float)imageSettings.Padding * 2);
                }

                Width = newWidth;
                Height = newHeight;

                if (sizeMode.HasFlag(SizeMode.Left))
                {
                    //deltaX = (int) (deltaX * 1.5);

                    //Left = rectOrigin.Left + (deltaX*2);
                    correction.X = deltaX;

                }
            }
        }

        private void global_MouseUp(object sender, MouseEventArgs e)
        {
            moveMode = MoveMode.None;
            label2.Text = moveMode.ToString();

            imageSettings.FrameSize = Size;
            imageSettings.Position = Location;
            imageSettings.ImageOffset = pbMain.Location;
            imageSettings.Zoom = zoom;

            imageSettings.Save();
        }
    }
}