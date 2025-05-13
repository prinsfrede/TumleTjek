using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;

namespace TumleTjek.ViewModel
{
    public class WorkerChildListViewModel : BaseViewModel
    {


        public ICommand GoBackButton { get; }
        public ICommand DoubleClickCommand { get; }


        private ChildViewModel _selectedChild;

        public ChildViewModel SelectedChild
        {
            get => _selectedChild;
            set
            {
                _selectedChild = value;
                OnPropertyChanged(nameof(SelectedChild));
            }
        }

        private ChildRepo barnRepo = new ChildRepo();

        public ObservableCollection<ChildViewModel> ChildVM { get; set; }

        public WorkerChildListViewModel(NavigationStore navigationStore)
        {


            ChildVM = new ObservableCollection<ChildViewModel>();
            foreach (Child barn in barnRepo.GetAll())
            {
                ChildVM.Add(new ChildViewModel(barn, barn.Name, barn.Age, barn.Details, barn.Parents, barn.IsMet));
            }

            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new EmployeeViewModel(navigationStore)));
            DoubleClickCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => new ChildUpdateViewModel(navigationStore, SelectedChild)));
        }

    }
}
