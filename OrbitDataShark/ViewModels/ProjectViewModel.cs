using OrbitDataShark.Models;
using OrbitDataShark.Services;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OrbitDataShark.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        public ObservableCollection<ProjectItem> Projects { get; } = new();
        public ICommand DeleteProjectCommand { get; }
        public ICommand OpenProjectCommand { get; }
        public ICommand SearchProjectCommand { get; }
        private readonly ProjectService? _projectService;

        public ProjectViewModel()
        {
            SearchProjectCommand = ReactiveCommand.CreateFromTask(async (string term) =>
            {
                await Task.CompletedTask;
            });
            _projectService = new ProjectService();
            DeleteProjectCommand = ReactiveCommand.CreateFromTask<Guid>(async (Guid id) =>
            {
                await Task.CompletedTask;
            }, outputScheduler: RxApp.MainThreadScheduler);
            OpenProjectCommand = ReactiveCommand.CreateFromTask<Guid>(async (Guid id) =>
            {
                
                await Task.CompletedTask;
            });
            LoadProjects();
        }

        private async void LoadProjects()
        {
            Projects.Clear();
            var projects = await _projectService!.GetProjects();
            foreach (var item in projects)
            {
                Projects.Add(new ProjectItem(item));
            }
        }
    }
}