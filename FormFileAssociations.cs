using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaku
{
    public partial class FormFileAssociations : Form
    {
        string iconPath;
        string appPath;

        RegistryKey Root
        {
            get
            {
                return rbAllUsers.Checked ? Registry.LocalMachine : Registry.CurrentUser;
            }
        }

        RegistryKey Classes
        {
            get
            {
                return Root.OpenSubKey("Software").OpenSubKey("Classes", true);
            }
        }

        public FormFileAssociations()
        {
            InitializeComponent();

            iconPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "gaku-document.ico");
            appPath = ToShortPathName(Application.ExecutablePath);
        }

        private void FormFileAssociations_Load(object sender, EventArgs e)
        {
            loadFromRegistry();
        }

       public bool SetAssociation(string extension, string progID)
       {
            var description = extension.Replace(".", "").ToUpper() + " Image";
            try
            {
                Classes.CreateSubKey(extension).SetValue("", progID);
                if (progID != null && progID.Length > 0)
                {
                    using (var key = Classes.CreateSubKey(progID))
                    {
                        key.SetValue("", description);
                        key.CreateSubKey("DefaultIcon").SetValue("", iconPath);
                        key.CreateSubKey(@"Shell\Open\Command").SetValue("", appPath + " \"%1\"");
                    }
                    return true;
                }
                return false;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                return false;
            }
        }

        public bool GetAssociation(string extension, string progID)
        {
            var sk = Classes.OpenSubKey(extension);
            if (sk == null) return false;
            return (sk.GetValue("", "") as string) == progID;
        }


        private void loadFromRegistry()
        {
            cbJpg.Checked = GetAssociation(".jpg", "gakuImageJpeg");
            cbPng.Checked = GetAssociation(".png", "gakuImagePng");
            cbBmp.Checked = GetAssociation(".bmp", "gakuImageBmp");
            cbGif.Checked = GetAssociation(".gif", "gakuImageGif");
        }

        void saveToRegistry()
        {
            if (cbJpg.Checked) SetAssociation(".jpg", "gakuImageJpeg");
            if (cbPng.Checked) SetAssociation(".png", "gakuImagePng");
            if (cbBmp.Checked) SetAssociation(".bmp", "gakuImageBmp");
            if (cbGif.Checked) SetAssociation(".gif", "gakuImageGif");
            Win32.SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = Win32.GetShortPathName(longName, s, iSize);
            return s.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToRegistry();
            Close();
        }
    }
}
