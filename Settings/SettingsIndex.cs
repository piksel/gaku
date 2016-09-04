using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaku
{
    public class SettingsIndex : GakuSettings
    {
        // Helpers for inherited methods
        public static SettingsIndex Load() { return Load<SettingsIndex>(SettingsFile); }
        public void Save() { Save(SettingsFile); }

        public static string SettingsFile { get { return Path.Combine(RootPath, "index.yaml"); } }

        public Dictionary<string, Guid> Files { get; set; } = new Dictionary<string, Guid>();

        public Guid GetGuid(string filename)
        {
            if (!Files.ContainsKey(filename))
            {
                Files.Add(filename, Guid.NewGuid());
                Save();
            }
            return Files[filename];
        }


    }
}
