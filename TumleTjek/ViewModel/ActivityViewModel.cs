using System.Collections.ObjectModel;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Services;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;


namespace TumleTjek.ViewModel
{
    public class ActivityViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; }

        private readonly ActivityService _activityService;
        

        // Bind direkte til den delte ObservableCollection
        public ObservableCollection<Activity> Activities => _activityService.Activities;

        private Activity _selectedActivity;
        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                if (_selectedActivity != value)
                {
                    _selectedActivity = value;
                    OnPropertyChanged(nameof(SelectedActivity));
                }
            }
        }

        // Konstruktoren med ActivityService
        public ActivityViewModel(NavigationStore navigationStore,ActivityService activityService)
        {
            _activityService = activityService;
            GoBackCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => new EmployeeViewModel(navigationStore)));
        }
       
    }
}

