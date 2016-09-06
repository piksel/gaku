using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var args = Environment.GetCommandLineArgs();

            var alpha = false;

            if (args.Length > 1)
            {
                var image = Image.FromFile(args[1]);

                alpha = image.HasAlpha() && !image.IsAnimated();
                
            }

            Application.Run(new FormGaku(alpha));
        }
    }
}
