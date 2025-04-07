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
        public ICommand Button_Click_StatusFra { get; }

        public MedarbejderViewModel()
        {
            AddChildButton = new RelayCommand(AddChildButtonExecute);
            Button_Click_StatusFra = new RelayCommand(Button_Click_StatusFraExcute);
        }


        private void AddChildButtonExecute(object parameter)
        {
            CreateChild createChild = new CreateChild();
            createChild.Show();
        }
        private void Button_Click_StatusFraExcute(object parameter)
        {
            FravaerPage fravaerPage = new FravaerPage();
            fravaerPage.Show();
        }

    }
}
