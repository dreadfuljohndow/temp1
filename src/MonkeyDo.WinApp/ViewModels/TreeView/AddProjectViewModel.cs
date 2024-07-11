using ReactiveUI;
using System;
using System.Reactive;
using MonkeyDo.WinApp.DataModel;
using MonkeyDo.WinApp.Services;

namespace MonkeyDo.WinApp.ViewModels.TreeView
{
    public class AddProjectViewModel : ViewModelBase
    {
        private readonly ProjectService _service;

        private string _description = string.Empty;
        private string _name = string.Empty;
        public ReactiveCommand<Unit, ProjectModel> OkCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddProjectViewModel(ProjectService service)
        {
            _service = service;
            var isValidObservable = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            OkCommand = ReactiveCommand.Create(() => new ProjectModel(_service)
            {
                Name = Name,
                Description = Description
            }, isValidObservable);
            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
    }
}