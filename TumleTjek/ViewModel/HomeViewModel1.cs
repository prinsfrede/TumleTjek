using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.View;
using TumleTjek.ViewModel;

namespace TumleTjek.ViewModel
{
    public class HomeViewModel1 : BaseViewModel
    {
        public ICommand ChildListButton { get; }
        public ICommand MedarbejderLoginButton { get; }


        public HomeViewModel1(NavigationStore navigationStore)
        {
            ChildListButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new ChildrenListViewModel(navigationStore)));
            MedarbejderLoginButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new MedarbejderLoginVM(navigationStore)));

        }





      



    }




}