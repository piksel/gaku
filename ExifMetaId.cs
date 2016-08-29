using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaku
{
    public static class ExifMetaId
    {
        static Dictionary<int, string> knownIds = new Dictionary<int, string>()
        {
            { 0x0320, "Image title" },
            { 0x010F, "Equipment manufacturer" },
            { 0x0110, "Equipment model" },
            { 0x9003, "ExifDTOriginal" },
            { 0x829A, "Exif exposure time" },
            { 0x5090, "Luminance table" },
            { 0x5091, "Chrominance table" },
        };

        public static string GetIdName(int id)
        {
            if (knownIds.ContainsKey(id)) return knownIds[id];
            return $"0x" + id.ToString("x");
        }

    }
}
