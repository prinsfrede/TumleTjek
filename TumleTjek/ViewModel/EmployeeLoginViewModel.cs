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
    public class EmployeeLoginViewModel : BaseViewModel
    {


        public ICommand LoginButton { get; }




        public EmployeeLoginViewModel(NavigationStore navigationStore)
        {
            LoginButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new EmployeeViewModel(navigationStore)));
        }

     
    }
}
