using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.Stores;

namespace TumleTjek.ViewModel
{
    public class ChildrenListViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        private BarnRepo barnRepo = new BarnRepo();

        public ObservableCollection<ChildViewModel> ChildVM { get; set; }


        public ChildrenListViewModel(NavigationStore navigationStore)
        {

            this._navigationStore = navigationStore;

            ChildVM = new ObservableCollection<ChildViewModel>();
            foreach (Child barn in barnRepo.GetAll())
            {
                ChildVM.Add(new ChildViewModel(barn, barn.Name, barn.Age, barn.Parents, barn.IsMet));
            }
        }
    }
}
