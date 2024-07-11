using System;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.VisualStudio.Services.CircuitBreaker;
using Microsoft.VisualStudio.Services.Common;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace MonkeyDo.WinApp.ViewModels.TreeView
{
    public class TreeViewToDoListViewModel : ViewModelBase
    {
        private ViewModelBase _contentViewModel;

        private readonly ToDoListService _service;
        private readonly ProjectService _projectService;
        public ObservableCollection<ToDoItemModel> ListItems { get; set; }

        public ObservableCollection<ProjectModel> ProjectItems { get; set; }

        public TreeViewViewModel ToDoList { get; set; }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }

        public TreeViewToDoListViewModel(ToDoListService toDoListService, ProjectService projectService)
        {
            _service = toDoListService;
            _projectService = projectService;
            LoadTasks();
            ContentViewModel = ToDoList;
        }

        public bool CanCreateItem()
        {
            return true;
        }

        public bool CanCreateProject()
        {
            return true;
        }


        private void LoadTasks()
        {
            var todoItems = _service.GetToDoItemsWithNoProject();

            var projects = _projectService.GetProjects().ToList();

            foreach (var project in projects)
            {
                project.ListItems.AddRange(_service.GetToDoItemsAssignedToProject(project.Id));
            }

            var fakeProject = new ProjectModel(_projectService, todoItems)
            {
                Name = "items",
                Description = "items not assigned to any project"
            };
            projects.Add(fakeProject);

            ListItems = new ObservableCollection<ToDoItemModel>(todoItems);

            ProjectItems = new ObservableCollection<ProjectModel>(projects);

            ToDoList = new TreeViewViewModel(todoItems, projects);
        }

        public void AddItem()
        {

            var projects = _projectService.GetProjects().ToList();


            AddItemViewModel addItemViewModel = new(_service, projects);

            Observable.Merge(
                    addItemViewModel.OkCommand,
                    addItemViewModel.CancelCommand.Select(_ => (ToDoItemModel?)null))
                .Take(1)
                .Subscribe(newItem =>
                                            {
                                                if (newItem != null)
                                                {
                                                    var service = new ToDoListService();
                                                    service.AddNewItem(newItem);
                                                }

                                                LoadTasks();
                                                ContentViewModel = ToDoList;
                                            }
                    );

            ContentViewModel = addItemViewModel;
        }

        public void EditItem(string id="")
        {
            var itemModel = _service.GetToDoItemById(id);

            var projects = _projectService.GetProjects().ToList();

            var editItemViewModel = new EditItemViewModel(_service, itemModel, projects);

            Observable.Merge(
                    editItemViewModel.OkCommand,
                    editItemViewModel.CancelCommand.Select(_ => (ToDoItemModel?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        var service = new ToDoListService();
                        var nI = service.UpdateToDoItem(newItem);
                        var items = ToDoList.ListItems;
                        var item = items.Single(i => i.Id == newItem.Id);
                        item.Description = newItem.Description;
                        item.IsChecked = newItem.IsChecked;
                    }
                    LoadTasks();

                    ContentViewModel = ToDoList;
                });

            ContentViewModel = editItemViewModel;
        }

        public void CreateProject()
        {
            AddProjectViewModel addProjectViewModel = new(_projectService);

            Observable.Merge(
                    addProjectViewModel.OkCommand,
                    addProjectViewModel.CancelCommand.Select(_ => (ProjectModel?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        var service = new ProjectService();
                        service.AddNewProject(newItem);
                    }
                    LoadTasks();

                    ContentViewModel = ToDoList;
                });

            ContentViewModel = addProjectViewModel;
        }

        public bool CanCreateProject(object parameter)
        {
            return true;
        }

    }
}