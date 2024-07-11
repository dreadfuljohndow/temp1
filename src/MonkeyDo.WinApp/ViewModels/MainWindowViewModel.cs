using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Md.AzureDevOps.DataProvider;
using ReactiveUI;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;
using MonkeyDo.WinApp.Views;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using Microsoft.VisualStudio.Services.Common;

namespace MonkeyDo.WinApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ToDoListService _service;
        private readonly ProjectService _projectService;

        public ToDoListViewModelBase ToDoList { get; private set; }

        private ViewModelBase _contentViewModel;

        private readonly MainWindow _mainWindow;

        //this has a dependency on the ToDoListService

        public MainWindowViewModel(MainWindow window)
        {
            _service = new ToDoListService();
            _projectService = new ProjectService();

            //LoadTasks();
            ToDoList = new ToDoListViewModelBase(_service, _projectService);
            _contentViewModel = ToDoList;

            _mainWindow = window;
        }


        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }



        public void ShowAboutInfo()
        {
            var aboutWindow = new AboutDialogWindow();

            aboutWindow.ShowDialog(_mainWindow);
        }

        public void ShowConfigureTaskSourceView()
        {
            var configItems = new List<ConfigureTaskExternalDataSourceItemViewModel>();
            configItems.Add(
                new ConfigureTaskExternalDataSourceItemViewModel
                {
                    ConfigType = "",
                    OrganizationName = "",
                    PAT = "",
                    SourceName = "",
                    ProjectName = ""
                });
            var configureTaskSources = new ConfigureTaskExternalDataSourceViewModel(configItems);
            ContentViewModel = configureTaskSources;
        }

        //load from azure. TODO DL: refactor and rename
        public void UpdateItems()
        {
            var azure = new AzureDevOpsServiceClient();
            //azure.LoadData();
            var r = azure.QueryOpenBugs("").Result;

            ToDoList.ListItems.Clear();
            foreach (var item in r)
            {
                ToDoList.ListItems.Add(new ToDoItemModel(_service)
                {
                    IsRed = false,
                    Description = $"id::{item.Id}, title::{item.Fields["System.Title"]}",
                    IsChecked = string.Equals((string?)item.Fields["System.State"], "Closed", StringComparison.InvariantCultureIgnoreCase)
                });
            }
            _contentViewModel = ToDoList;


            foreach (var r1 in r)
            {
                Console.WriteLine(r1);
            }
        }

        public void AppExit()
        {
            _mainWindow.Close();
        }
    }
}