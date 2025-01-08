using OrbitDataShark.DataGen.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrbitDataShark.ViewModels
{
    public class DatasetViewModel
    {
        private readonly Dataset _dataset;
        public string Name => _dataset.Name;
        public Guid Id => _dataset.Id;
        public ICommand OpenDatasetCommand { get; }
        public DatasetViewModel(Dataset dataset)
        {
            _dataset = dataset;
            OpenDatasetCommand = ReactiveCommand.CreateFromTask(async (Guid id) =>
            {
                await Task.CompletedTask;
            });

        }

        
    }
}
