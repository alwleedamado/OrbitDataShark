using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrbitDataShark.Core.ComponentModel;

namespace OrbitDataShark.Core.ProjectManagement
{
    public class Project
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, Dataset> Datasets { get; } = new();
        public Project(string name, string? description = null)
        {
            Name = name;
            Description = description;
        }

    }
}
