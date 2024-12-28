using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private ObservableCollection<ObjectId> datasets = [];

        [RelayCommand]
        public void OpenDataset(Guid id)
        {

        }
    }
}
