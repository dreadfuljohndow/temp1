using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MonkeyDo.WinApp.ViewModels;
using MonkeyDo.WinApp.Views;

namespace MonkeyDo.WinApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = new MainWindow();

                desktop.MainWindow = mainWindow;
                mainWindow.DataContext = new MainWindowViewModel(mainWindow);


                //desktop.MainWindow = new MainWindow
                //{
                //    DataContext = new MainWindowViewModel(),
                //};
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}