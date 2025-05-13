using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumleTjek.ViewModel
{
    public class AddActivtyViewModel : BaseViewModel
    {
        private string _activityName;
        private string _activityDescription;
        private string _activityDate;
        private string _activityTime;
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
    
    }
}
