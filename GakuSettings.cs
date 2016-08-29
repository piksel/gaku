using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaku
{
    public class GakuSettings
    {

        public static string RootPath { get; } = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "piksel bitworks", "Gaku");

        public static string TempImagePath { get; } = Path.Combine(RootPath, "temp");

        internal static string GetTempImageFilename(string extension = ".png")
        {
            Directory.CreateDirectory(TempImagePath);

            if (extension[0] != '.')
                extension = "." + extension;

            var guid = Guid.NewGuid();
            return Path.Combine(TempImagePath, guid + extension);
        }
    }
}
