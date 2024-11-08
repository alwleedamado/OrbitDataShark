
using System.Xml.Serialization;

using OrbitDataShark.Core.Data;

namespace OrbitDataShark.Core.Configuration
{
    public class ProjectConfiguration
    {
        public const string FileName = "Projects.xml";
        public string RootDirectory { get; }
        public static ProjectConfiguration Instance { get; } = new ProjectConfiguration();
        public ProjectConfigurationData Data { get;  }

        public ProjectConfiguration()
        {
            RootDirectory = Settings.Instance.Data.ProjectsDirectory;
            Data = XmlDataAccess.ReadData< ProjectConfigurationData>(RootDirectory);
        }

        public void SaveChanges()
        {
            var path = Path.Combine(Settings.AppRootPath, FileName);
            XmlDataAccess.SaveToDisk(path, Data);
        }
      
    }
}