using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.Services;
using System.Windows.Input;
using TumleTjek.View;
using TumleTjek.ViewModel;

namespace TumleTjek.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        public ICommand ActivityButton { get; }
        public ICommand AddChildButton { get; }
        public ICommand AbsenceButton { get; }
        public ICommand ChildListButton { get; }
        public ICommand AddActivityButton { get; }
        public ICommand GoBackButton { get; }

        private readonly ActivityService _activityService;

        public EmployeeViewModel(NavigationStore navigationStore)
        {
            // Opret en delt instans af ActivityService
            IActivityRepo repo = new ActivityRepo();
            _activityService = new ActivityService(repo);

            ActivityButton = new NavigateCommand(new NavigationService(navigationStore,
                () => new ActivityViewModel(navigationStore, _activityService)));
            AddChildButton = new NavigateCommand(new NavigationService(navigationStore,
                () => new CreateChildViewModel(navigationStore)));
            AbsenceButton = new NavigateCommand(new NavigationService(navigationStore,
                () => new AbsenceViewModel(navigationStore)));
            ChildListButton = new NavigateCommand(new NavigationService(navigationStore,
                () => new WorkerChildListViewModel(navigationStore)));
            // Her sendes den samme _activityService videre til AddActivityViewModel
            AddActivityButton = new NavigateCommand(new NavigationService(navigationStore,
                () => new AddActivityViewModel(navigationStore, _activityService)));
            GoBackButton = new NavigateCommand(new NavigationService(navigationStore,
                () => new HomeViewModel1(navigationStore)));
        }
    }
}
