using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using OrbitDataShark.Core.Data;

namespace OrbitDataShark.Core.Configuration
{
    internal class Settings
    {
        private const string SettingsFileName = "setting.xml";
        public static readonly string AppRootPath = AppDomain.CurrentDomain.BaseDirectory;
        public static Settings Instance { get; } = new Settings();
        public SettingsData Data { get; }
        public Settings()
        {
            var path = Path.Combine(AppRootPath, SettingsFileName);
            Data = XmlDataAccess.ReadData<SettingsData>(path);
        }
        public void SaveChanges()
        {
            var path = Path.Combine(AppRootPath, SettingsFileName);
            XmlDataAccess.SaveToDisk(path, Data);
        }
    }
}
