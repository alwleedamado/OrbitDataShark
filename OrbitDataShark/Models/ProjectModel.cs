using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.Models
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public ProjectModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}