using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    public static class DataFormatsEx
    {
        public static string URL = "UniformResourceLocator";

        internal static string GetDataString(IDataObject data, string dataformat)
        {
            string output = string.Empty;
            using(var sr = new StreamReader(data.GetData(dataformat) as MemoryStream))
            {
                while (sr.Peek() > 0)
                    output += (char)sr.Read();
            }
            return output;
        }
    }
}
