using Microsoft.TeamFoundation.TestManagement.WebApi;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyDo.WinApp.ViewModels.TreeView
{
    public class TreeViewViewModel : ViewModelBase
    {
        public ObservableCollection<ToDoItemModel> ListItems { get; set; }

        public ObservableCollection<ProjectModel> ProjectItems { get; set; }

        public TreeViewViewModel(IEnumerable<ToDoItemModel> items, IEnumerable<ProjectModel> projects)
        {
            ListItems = new ObservableCollection<ToDoItemModel>(items);
            ProjectItems = new ObservableCollection<ProjectModel>(projects);

            DoTheThing = ReactiveCommand.Create(RunTheThing);
        }
        public ReactiveCommand<Unit, Unit> DoTheThing { get; }

        void RunTheThing()
        {
            // Code for executing the command here.
        }

        public void EditItem(string param1)
        {
            Console.WriteLine("here");
        }

        public void Do()
        {}
    }
}
