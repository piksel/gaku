using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Gaku
{
    public class ImageSettings: GakuSettings
    {
        public void Save() { Save(SettingsFilePath(FileName)); }

        public string FileName { get; set; }
        public double Zoom { get; set; } = 1.0;
        public Point ImageOffset { get; set; } = new Point(0, 0);
        public Point Position { get; set; } = Point.Empty;
        public Size FrameSize { get; set; } = new Size(800, 600);
        public DisplayMode DisplayMode { get; set; }

        public BorderStyle BorderStyle { get; set; } = BorderStyle.None;
        public int BorderWidth { get; set; } = 2;

        [YamlIgnore]
        public int Padding { get { return BorderStyle == BorderStyle.Custom ? BorderWidth : 0; } }

        [YamlIgnore]
        public Color BorderColor { get; set; } = Color.Black;

        [YamlMember(Alias = "BorderColor")]
        public string BorderColorComponents {
            get {
                return ColorTranslator.ToHtml(BorderColor);
            }
            set
            {
                BorderColor = ColorTranslator.FromHtml(value);
            }
        }

        [YamlIgnore]
        public bool New { get; set; }

        public static ImageSettings Default { get { return ForFile(string.Empty); } }

        public static ImageSettings ForFile(string file)
        {
            var settingsFile = SettingsFilePath(file);
            if (File.Exists(settingsFile)) {
                return Load<ImageSettings>(settingsFile);
            }

            return new ImageSettings() { FileName = file, DisplayMode = DisplayMode.AutoFit, New = true };

        }

        static SettingsIndex _index;
        static SettingsIndex Index {
            get
            {
                if(_index == null)
                {
                    _index = SettingsIndex.Load();
                }
                return _index;
            }
        }



        static string SettingsFilePath(string filename)
        {


            string settingsPath = Path.Combine(SettingsIndex.RootPath, "ImageSettings");

            Directory.CreateDirectory(settingsPath);

            if (!string.IsNullOrEmpty(filename))
            {
                var guid = Index.GetGuid(filename);

                return Path.Combine(settingsPath, string.Concat(guid.ToString(), ".yaml"));
            }
            else
            {
                return Path.Combine(SettingsIndex.RootPath, string.Concat("default", ".yaml"));
            }


        }
    }


}
