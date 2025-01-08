using OrbitDataShark.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.ViewModels
{
    internal partial class ProjectDetailviewModel : ViewModelBase
    {
        private readonly ProjectModel _project;

        public ProjectDetailviewModel(ProjectModel project)
        {
            _project = project;
        }

        public string Name => _project.Name;
        public Guid Id => _project.Id;

        private ObservableCollection<ObjectId> Datasets = [];

        
    }
}
