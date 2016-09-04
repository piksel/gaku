using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Gaku
{
    public class GeneralSettings: GakuSettings
    {
        // Helpers for inherited methods
        public static GeneralSettings Load() { return Load<GeneralSettings>(SettingsFile); }
        public void Save() { Save(SettingsFile); }

        public static string SettingsFile { get { return Path.Combine(RootPath, "settings.yaml"); } }

        public bool KeepAspectRatio { get; set; }
        public bool FastTextDraw { get; set; }

        bool _notFirstStart = false;
        [YamlMember(Alias = "notFirstStart")]
        public bool notFirstStart
        {
            get { return _notFirstStart; }
            set { _notFirstStart = value; }
        }

        [YamlIgnore]
        public bool FirstStart
        {
            get { return !_notFirstStart; }
            set { _notFirstStart = !value; }
        }
    }
}
