using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrbitDataShark.Core.Configuration;
using OrbitDataShark.Core.Data;

namespace OrbitDataShark.Core.ProjectManagement
{
    public class ProjectManager
    {
        public List<Project> Projects { get; } = new List<Project>();
        private readonly string projectsPath;
        public ProjectManager()
        {
            projectsPath = Settings.Instance.Data.ProjectsDirectory;
        }
        public void NewProject(Project project)
        {
            var path = Path.Combine(projectsPath, project.Name);
            Directory.CreateDirectory(path);
            var configPath = Path.Combine(path, project.Name);
            XmlDataAccess.SaveToDisk(configPath, project);
            Projects.Add(project);
            ProjectConfiguration.Instance.SaveChanges();
        }
        public void DeleteProject(Project project)
        {
            Projects.Remove(project);
            ProjectConfiguration.Instance.SaveChanges();
            var path = Path.Combine(projectsPath, project.Name);
            Directory.Delete(path);
        }
    }
}
