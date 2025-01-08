using DynamicData;
using OrbitDataShark.DataGen.Models;
using OrbitDataShark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.Services
{
    public class ProjectService
    {
        public Task<List<Project>> GetProjects()
        {
            return Task.FromResult(new List<Project>() {
            new Project(Guid.NewGuid(), "Cannary Call"),
            new Project(Guid.NewGuid(), "Library"),
            });
        }

        public async Task DeleteProject(Guid id)
        {
            await Task.CompletedTask;
        }
    }
}
