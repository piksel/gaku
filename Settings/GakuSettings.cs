using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Gaku
{
    public class GakuSettings
    {

        public static string RootPath { get; } = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "piksel bitworks", "Gaku");

        public static string TempImagePath { get; } = Path.Combine(RootPath, "temp");

        public static INamingConvention SettingsNamingConvention { get { return new CamelCaseNamingConvention(); } }

        internal static string GetTempImageFilename(string extension = ".png")
        {
            Directory.CreateDirectory(TempImagePath);

            if (extension[0] != '.')
                extension = "." + extension;

            var guid = Guid.NewGuid();
            return Path.Combine(TempImagePath, guid + extension);
        }

        public static T Load<T>(string settingsFile) where T: new()
        {
            if (File.Exists(settingsFile))
            {
                var yaml = new Deserializer(namingConvention: SettingsNamingConvention);

                using (var sr = new StreamReader(settingsFile))
                {
                    var index = yaml.Deserialize<T>(sr);
                    return index;
                }
            }
            else
            {
                return new T() { };
            }
        }

        public void Save(string settingsFile)
        {
            var settingsPath = Path.GetDirectoryName(settingsFile);
            Directory.CreateDirectory(settingsPath);

            var yaml = new Serializer(namingConvention: SettingsNamingConvention);

            using (var sw = new StreamWriter(settingsFile))
            {
                yaml.Serialize(sw, this);
            }
        }
    }
}
