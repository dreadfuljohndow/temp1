using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MonkeyDo.WinApp.ViewModels
{
    public class ConfigureTaskExternalDataSourceViewModel : ViewModelBase
    {
        public ObservableCollection<ConfigureTaskExternalDataSourceItemViewModel> ConfigItems { get; }

        public ConfigureTaskExternalDataSourceViewModel(IEnumerable<ConfigureTaskExternalDataSourceItemViewModel> configItems)
        {
            ConfigItems = new ObservableCollection<ConfigureTaskExternalDataSourceItemViewModel>(configItems);
        }
    }
}