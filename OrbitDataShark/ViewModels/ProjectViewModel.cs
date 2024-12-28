using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace OrbitDataShark.ViewModels
{
    public partial class ProjectViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<ObjectId> projects = [new ObjectId (Guid.NewGuid(),"OrbitFood"),
        new ObjectId (Guid.NewGuid(),"OrbitFood"),
            new(Guid.NewGuid(),"CanaryCall"),
        ];
        [ObservableProperty]
        private ObservableCollection<ObjectId> filteredProects = [];

        [RelayCommand]
        public void SearchProject(string term)
        {
            var filtered = Projects.Where(x => x.Name.StartsWith(term));

        }
    }

    public record ObjectId(Guid Id, string Name);
}