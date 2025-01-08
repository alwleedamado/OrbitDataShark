using OrbitDataShark.DataGen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitDataShark.ViewModels
{
    public class ProjectItem
    {
        private readonly Project _project;
        public string Name => _project.Name;
        public Guid Id => _project.Id;
        public ObservableCollection<DatasetViewModel> Datasets { get; }
        public ProjectItem(Project project)
        {
            _project = project;
            Datasets = new ObservableCollection<DatasetViewModel>(_project.Datasets
                .Select(x => new DatasetViewModel(x)).ToList());
        }
    }
}
