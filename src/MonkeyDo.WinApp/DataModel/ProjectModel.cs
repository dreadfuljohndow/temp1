using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonkeyDo.WinApp.Services;

namespace MonkeyDo.WinApp.DataModel
{
    public class ProjectModel : INotifyPropertyChanged
    {
        private readonly ProjectService _service;

        public ObservableCollection<ToDoItemModel> ListItems { get; }

        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ProjectModel(ProjectService service, IEnumerable<ToDoItemModel>? items = null)
        {
            _service = service;
            
            items ??= new List<ToDoItemModel>();

            ListItems = new ObservableCollection<ToDoItemModel>(items);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
