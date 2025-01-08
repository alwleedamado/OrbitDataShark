using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.DataGen.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Dataset> Datasets { get; set; } = new();
        public Project(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
