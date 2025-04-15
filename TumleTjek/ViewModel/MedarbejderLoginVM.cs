using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.View;

namespace TumleTjek.ViewModel
{
    public class MedarbejderLoginVM : BaseViewModel
    {


        public ICommand LoginButton { get; }




        public MedarbejderLoginVM(NavigationStore navigationStore)
        {
            LoginButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new MedarbejderViewModel(navigationStore)));
        }

     
    }
}
