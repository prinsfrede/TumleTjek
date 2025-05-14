using ScottPlot;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.View;

namespace TumleTjek.ViewModel
{
    public class AddActivtyViewModel : BaseViewModel
    {
        private string _activityName;
        private string _activityDescription;
        private string _activityDate;
        private string _activityTime;
        private ActivtyRepo activtyRepo = new ActivtyRepo();
        public ICommand AddActivityButton { get; }
        public ICommand GoBackButton { get; }
        public AddActivtyViewModel(NavigationStore navigationStore)
        {
            AddActivityButton = new RelayCommand(AddActivtyButtonExecute);
            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new EmployeeViewModel(navigationStore)));
        }
        public string ActivityName
        {
            get => _activityName;
            set
            {
                _activityName = value;
                OnPropertyChanged(nameof(ActivityName));
            }
        }
        public string ActivityDescription
        {
            get => _activityDescription;
            set
            {
                _activityDescription = value;
                OnPropertyChanged(nameof(ActivityDescription));
            }
        }
        public string ActivityDate
        {
            get => _activityDate;
            set
            {
                _activityDate = value;
                OnPropertyChanged(nameof(ActivityDate));
            }
        }
        public string ActivityTime
        {
            get => _activityTime;
            set
            {
                _activityTime = value;
                OnPropertyChanged(nameof(ActivityTime));
            }
        }
        private string _activityDuration;
        private string _activityLocation;

        public string ActivityDuration
        {
            get => _activityDuration;
            set
            {
                _activityDuration = value;
                OnPropertyChanged(nameof(ActivityDuration));
            }
        }

        public string ActivityLocation
        {
            get => _activityLocation;
            set
            {
                _activityLocation = value;
                OnPropertyChanged(nameof(ActivityLocation));
            }
        }

        private void AddActivtyButtonExecute(object obj)
        {
            if (string.IsNullOrEmpty(ActivityName) ||
                string.IsNullOrEmpty(ActivityDescription) ||
                string.IsNullOrEmpty(ActivityDate) ||
                string.IsNullOrEmpty(ActivityDuration) ||
                string.IsNullOrEmpty(ActivityLocation))

            {
                MessageBox.Show("Udfyld alle felter.");
                return;
            }

            Activty activty = new Activty
            {
                Name = ActivityName,
                Description = ActivityDescription,
                Date = DateTime.Parse(ActivityDate),
                Location = ActivityLocation,
                Duration = ActivityDuration
            };

            activtyRepo.Add(activty);
            MessageBox.Show("Aktivitet tilføjet");
        }
        //private void AddActivtyButtonExecute(object obj)
        //{
        //    if (string.IsNullOrEmpty(ActivityName) || string.IsNullOrEmpty(ActivityDescription) || string.IsNullOrEmpty(ActivityDate) || string.IsNullOrEmpty(ActivityTime))
        //    )
        //    {
        //        MessageBox.Show("Udfyld alle felter.");
        //        return;
        //    }

        //    ActivtyRepo activty = new ActivtyRepo
        //    {
        //        Name = ActivityName,
        //        Description = ActivityDescription,
        //        Date = ActivityDate,
        //        Time = ActivityTime
        //    };
        //    activtyRepo.AddActivty(activty);
        //    MessageBox.Show("Aktivitet tilføjet");
        //}

    }
}
