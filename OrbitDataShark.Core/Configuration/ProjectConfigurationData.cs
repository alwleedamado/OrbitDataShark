using OrbitDataShark.Core.ProjectManagement;

namespace OrbitDataShark.Core.Configuration
{
    public class ProjectConfigurationData
    {
        public string ProjectsRootDirectory { get; set; } = string.Empty;
        public List<Project> Projects { get; set; } = [];
    }
}