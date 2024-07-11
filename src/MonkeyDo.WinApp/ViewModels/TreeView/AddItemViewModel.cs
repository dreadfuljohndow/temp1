using ReactiveUI;
using System;
using System.Reactive;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyDo.WinApp.ViewModels.TreeView
{
    public class AddItemViewModel : ViewModelBase
    {
        private readonly ToDoListService _service;

        private string _description = string.Empty;

        private ProjectModel _assignedProject;
        public ReactiveCommand<Unit, ToDoItemModel> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddItemViewModel(ToDoListService service, List<ProjectModel> projects)
        {
            _service = service;
            Projects = projects;
            _assignedProject = null;//projects.FirstOrDefault();

            var isValidObservable = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            OkCommand = ReactiveCommand.Create(() => new ToDoItemModel(_service)
            {
                ProjectId = AssignedProject?.Id,
                Description = Description
            }, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public ProjectModel AssignedProject
        {
            get => _assignedProject;
            set => this.RaiseAndSetIfChanged(ref _assignedProject, value);
        }
        public List<ProjectModel> Projects { get; }
    }
}