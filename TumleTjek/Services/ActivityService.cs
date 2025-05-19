using System.Collections.ObjectModel;
using TumleTjek.Model;
using TumleTjek.Repo;

namespace TumleTjek.Services
{
    public class ActivityService
    {
        private readonly IActivityRepo _activityRepo;

        // Denne ObservableCollection skal deles på tværs af viewmodels.
        public ObservableCollection<Activity> Activities { get; }

        public ActivityService(IActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
            // Hent aktiviteterne én gang ved opstart
            Activities = new ObservableCollection<Activity>(_activityRepo.GetAllActivities());
        }

        public void AddActivity(Activity activity)
        {
            // Tilføj aktiviteten til databasen
            _activityRepo.Add(activity);
            // Tilføj aktiviteten til den delte ObservableCollection – UI binder til denne.
            Activities.Add(activity);
        }
    }
}
