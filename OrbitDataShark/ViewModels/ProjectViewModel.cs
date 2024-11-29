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
        private ObservableCollection<ProjectID> projects = [];
        [ObservableProperty]
        private ObservableCollection<ProjectID> filteredProects = [];

        [RelayCommand]
        public void SearchProject(string term)
        {
            var filtered = projects.Where(x => x.Name.StartsWith(term));

        }
    }

    public record ProjectID(Guid Id, string Name);
}