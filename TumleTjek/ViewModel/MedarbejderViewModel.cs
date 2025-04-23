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

namespace TumleTjek.ViewModel
{
    public class MedarbejderViewModel : BaseViewModel
    {

        public ICommand AddChildButton { get; }
        public ICommand AbsenceButton { get; }

        public ICommand ChildListButton { get; }
        public ICommand GoBackButton { get; }

        public MedarbejderViewModel(NavigationStore navigationStore)
        {
            AddChildButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new CreateChildViewModel(navigationStore)));
            AbsenceButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new AbsenceViewModel(navigationStore)));
            ChildListButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new WorkerChildListViewModel(navigationStore)));
            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new HomeViewModel1(navigationStore)));
        }


       

    }
}
