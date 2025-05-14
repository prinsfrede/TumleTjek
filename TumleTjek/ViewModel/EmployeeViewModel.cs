using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.View;
using TumleTjek.ViewModel;
using TumleTjek.Services;
using System.Diagnostics;

namespace TumleTjek.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        public ICommand ActivtyButton { get; }
        public ICommand AddChildButton { get; }
        public ICommand AbsenceButton { get; }

        public ICommand ChildListButton { get; }
        public ICommand AddActivtyButton { get; }
        public ICommand GoBackButton { get; }
      

        public EmployeeViewModel(NavigationStore navigationStore)
        {
            ActivtyButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new ActivtyViewModel(navigationStore)));
            AddChildButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new CreateChildViewModel(navigationStore)));
            AbsenceButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new AbsenceViewModel(navigationStore)));
            ChildListButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new WorkerChildListViewModel(navigationStore)));
            AddActivtyButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new AddActivtyViewModel(navigationStore)));
            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new HomeViewModel1(navigationStore)));
        }


       

    }
}
