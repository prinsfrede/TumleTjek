using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.TechnicalServices;
using TumleTjek.View;

namespace TumleTjek.ViewModel
{
    public class MedarbejderViewModel
    {

        public ICommand AddChildButton { get; }

        public MedarbejderViewModel()
        {
            AddChildButton = new RelayCommand(AddChildButtonExecute);
        }


        private void AddChildButtonExecute(object parameter)
        {
            CreateChild createChild = new CreateChild();
            createChild.Show();
        }

    }
}
