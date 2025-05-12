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
using TumleTjek.Model;
using TumleTjek.Services;

namespace TumleTjek.ViewModel
{
    public class ActivtyViewModel : BaseViewModel
    {
        public ICommand GoBackButton { get; }

        public ActivtyViewModel(NavigationStore navigationStore)
        {
            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new HomeViewModel1(navigationStore)));
        }

    }
}
