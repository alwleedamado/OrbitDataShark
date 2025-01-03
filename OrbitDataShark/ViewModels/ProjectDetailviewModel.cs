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
        public string Name = string.Empty;

        private ObservableCollection<ObjectId> Datasets = [];

        
    }
}
