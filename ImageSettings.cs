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
    public class ImageSettings
    {
        public string FileName { get; set; }
        public double Zoom { get; set; } = 1.0;
        public Point ImageOffset { get; set; } = new Point(0, 0);
        public Point Position { get; set; } = Point.Empty;
        public Size FrameSize { get; set; } = new Size(800, 600);
        public DisplayMode DisplayMode { get; set; }

        public BorderStyle BorderStyle { get; set; } = BorderStyle.None;
        public int BorderWidth { get; set; } = 2;

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

        public void Save()
        {
            var settingsFile = SettingsFilePath(FileName);
            var yaml = new Serializer(namingConvention: new CamelCaseNamingConvention());

            using (var sw = new StreamWriter(settingsFile))
            {
                yaml.Serialize(sw, this);
            }
        }

        public static ImageSettings Default { get { return ForFile(string.Empty); } }

        public static ImageSettings ForFile(string file)
        {
            var settingsFile = SettingsFilePath(file);
            if (File.Exists(settingsFile)) {
                var yaml = new Deserializer(namingConvention: new CamelCaseNamingConvention());

                using(var sr = new StreamReader(settingsFile))
                {
                    var settings = yaml.Deserialize<ImageSettings>(sr);
                    if (settings != null)
                        return settings;
                }

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

    public class SettingsIndex: GakuSettings
    {
        public Dictionary<string, Guid> Files { get; set; }

        static string IndexFile { get { return Path.Combine(RootPath, "index.yaml"); } }

        public Guid GetGuid(string filename)
        {
            if(!Files.ContainsKey(filename))
            {
                Files.Add(filename, Guid.NewGuid());
                Save();
            }
            return Files[filename];
        }

        public static SettingsIndex Load()
        {
            if (File.Exists(IndexFile))
            {
                var yaml = new Deserializer(namingConvention: new CamelCaseNamingConvention());

                using (var sr = new StreamReader(IndexFile))
                {
                    var index = yaml.Deserialize<SettingsIndex>(sr);
                    return index;
                }
            }
            else
            {
                return new SettingsIndex() { Files = new Dictionary<string, Guid>() };
            }
        }

        public void Save()
        {
            var yaml = new Serializer(namingConvention: new CamelCaseNamingConvention());

            using (var sw = new StreamWriter(IndexFile))
            {
                yaml.Serialize(sw, this);
            }
        }
    }
}
