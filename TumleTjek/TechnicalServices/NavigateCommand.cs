using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Services;

namespace TumleTjek.TechnicalServices
{
    public class NavigateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly NavigationService navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            navigationService.Navigate();
        }
    }
}
