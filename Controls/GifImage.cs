﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaku
{
    public class GifImage
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int frameCount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;

        public GifImage(string path): this(Image.FromFile(path)) { }
        public GifImage(Bitmap bmp): this(bmp as Image) { }

        public GifImage(Image image)
        {
            gifImage = image;
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]); //gets the GUID
            frameCount = gifImage.GetFrameCount(dimension); //total frames in the animation
        }

        public bool ReverseAtEnd //whether the gif should play backwards when it reaches the end
        {
            get { return reverse; }
            set { reverse = value; }
        }

        public Image GetNextFrame()
        {

            currentFrame += step;

            //if the animation reaches a boundary...
            if (currentFrame >= frameCount || currentFrame < 1)
            {
                if (reverse)
                {
                    step *= -1; //...reverse the count
                    currentFrame += step; //apply it
                }
                else
                    currentFrame = 0; //...or start over
            }
            return GetFrame(currentFrame);
        }

        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index); //find the frame
            return (Image)gifImage.Clone(); //return a copy of it
        }
    }
}
