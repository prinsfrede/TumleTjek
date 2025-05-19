using System;
using System.Windows;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Services;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;

namespace TumleTjek.ViewModel
{
    public class AddActivityViewModel : BaseViewModel
    {
        private string _activityName;
        private string _activityDescription;
        private DateTime? _activityDate;
        private string _activityDuration;
        private string _activityLocation;
        private readonly NavigationStore _navigationStore;
        private readonly ActivityService _activityService;

        // Modtag nu en ActivityService i konstruktøren
        public AddActivityViewModel(NavigationStore navigationStore, ActivityService activityService)
        {
            _navigationStore = navigationStore;
            _activityService = activityService;
            AddActivityCommand = new RelayCommand(AddActivityExecute, CanExecuteAdd);
            GoBackCommand = new NavigateCommand(new NavigationService(_navigationStore, () => new EmployeeViewModel(_navigationStore)));
        }

        public string ActivityName
        {
            get => _activityName;
            set
            {
                _activityName = value;
                OnPropertyChanged();
                ((RelayCommand)AddActivityCommand).RaiseCanExecuteChanged();
            }
        }

        public string ActivityDescription
        {
            get => _activityDescription;
            set
            {
                _activityDescription = value;
                OnPropertyChanged();
                ((RelayCommand)AddActivityCommand).RaiseCanExecuteChanged();
            }
        }

        public DateTime? ActivityDate
        {
            get => _activityDate;
            set
            {
                _activityDate = value;
                OnPropertyChanged();
                ((RelayCommand)AddActivityCommand).RaiseCanExecuteChanged();
            }
        }

        public string ActivityDuration
        {
            get => _activityDuration;
            set
            {
                _activityDuration = value;
                OnPropertyChanged();
                ((RelayCommand)AddActivityCommand).RaiseCanExecuteChanged();
            }
        }

        public string ActivityLocation
        {
            get => _activityLocation;
            set
            {
                _activityLocation = value;
                OnPropertyChanged();
                ((RelayCommand)AddActivityCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddActivityCommand { get; }
        public ICommand GoBackCommand { get; }

        private bool CanExecuteAdd(object parameter)
        {
            return !string.IsNullOrWhiteSpace(ActivityName) &&
                   !string.IsNullOrWhiteSpace(ActivityDescription) &&
                   ActivityDate.HasValue &&
                   !string.IsNullOrWhiteSpace(ActivityDuration) &&
                   !string.IsNullOrWhiteSpace(ActivityLocation);
        }

        private void AddActivityExecute(object parameter)
        {
            Activity newActivity = new Activity
            {
                Name = ActivityName,
                Description = ActivityDescription,
                Date = ActivityDate.Value,
                Duration = ActivityDuration,
                Location = ActivityLocation
            };

            _activityService.AddActivity(newActivity);
            MessageBox.Show("Aktivitet tilføjet succesfuldt!");

            // Ryd felterne
            ActivityName = string.Empty;
            ActivityDescription = string.Empty;
            ActivityDate = null;
            ActivityDuration = string.Empty;
            ActivityLocation = string.Empty;
        }
    }
}
