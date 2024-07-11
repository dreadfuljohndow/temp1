using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.VisualStudio.Services.CircuitBreaker;
using Microsoft.VisualStudio.Services.Common;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;
using MonkeyDo.WinApp.ViewModels.FlatView;
using MonkeyDo.WinApp.ViewModels.MindMap;
using MonkeyDo.WinApp.ViewModels.TreeView;
using ReactiveUI;

namespace MonkeyDo.WinApp.ViewModels
{
    public class ToDoListViewModelBase : ViewModelBase
    {


        private ViewModelBase _contentViewModel;

        public ObservableCollection<ToDoItemModel> ListItems { get;  set; }

        public ObservableCollection<ProjectModel> ProjectItems { get;  set; }

        public TreeViewToDoListViewModel ToDoList { get; set; }

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }


        public void ShowFlatView()
        {
            var flatView = new FlatViewViewModel();
            ContentViewModel = flatView;
        }

        public void ShowTreeView()
        {
            //LoadTasks();
            ContentViewModel = ToDoList;
        }

        public void ShowMindMap()
        {
            var mindMap = new MindMapViewModel();
            ContentViewModel = mindMap;
        }

        public ToDoListViewModelBase(ToDoListService toDoListService, ProjectService projectService)
        {
            var items = new TreeViewToDoListViewModel(toDoListService, projectService);
            ToDoList = items;
            ContentViewModel = ToDoList;
        }
    }
}