using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using TumleTjek.Stores;
using TumleTjek.ViewModel;

namespace TumleTjek
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new HomeViewModel1(navigationStore);

            var mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore),
            };
            MainWindow = mainWindow;
            mainWindow.Show();


            base.OnStartup(e);

           
        }
    }

}
