using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;

namespace MonkeyDo.WinApp.ViewModels.TreeView
{
    public class EditItemViewModel : ViewModelBase
    {
        private readonly ToDoListService _service;

        private string _description = string.Empty;
        private ToDoItemModel _toDoItemModel;

        private ProjectModel _assignedProject;

        public ReactiveCommand<Unit, ToDoItemModel> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public EditItemViewModel(ToDoListService service, ToDoItemModel item, List<ProjectModel> projects)
        {
            _service = service;
            _toDoItemModel = item;
            _description = item.Description;
            Projects = projects;
            _assignedProject = projects.FirstOrDefault(p => p.Id == item.ProjectId);


            var isValidObservable = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            OkCommand = ReactiveCommand.Create(() =>
            {
                _toDoItemModel.ProjectId = AssignedProject.Id;
                _toDoItemModel.Description = Description;
                return _toDoItemModel;
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