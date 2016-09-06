using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaku
{
    public static class ImageEx
    {
        public static bool IsAnimated(this Image image)
        {
            var dimension = new FrameDimension(image.FrameDimensionsList[0]);
            var frameCount = image.GetFrameCount(dimension);
            return (frameCount > 1);
        }

        public static bool HasAlpha(this Image image)
        {
            return image.PixelFormat == PixelFormat.Format32bppArgb;
        }
    }
}
