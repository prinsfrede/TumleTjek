using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.View;
using TumleTjek.ViewModel;
using TumleTjek.Services;
using TumleTjek.Model;

namespace TumleTjek.ViewModel
{
    class AbsenceViewModel: BaseViewModel
    {
        public ICommand GoBackCommand { get; }
        public AbsenceViewModel(NavigationStore navigationStore)
        {
            GoBackCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => new MedarbejderViewModel(navigationStore)));
        }
        
    }
}
