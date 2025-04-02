using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using TumleTjek.TechnicalServices;
using TumleTjek.View;

namespace TumleTjek.ViewModel
{
    public class MainViewModel
    {
        public ICommand ChildListButton { get; }
        public ICommand MedarbejderLoginButton { get; }


        public MainViewModel()
        {
            ChildListButton = new RelayCommand(ChildListButtonExecute);
            MedarbejderLoginButton = new RelayCommand(MedarbejderLoginButtonExecute);
        }



        private void ChildListButtonExecute(object parameter)
        {
            var frame = parameter as Frame;
            if (frame != null)
            {
                frame.Navigate(new ChildrenList());
            }

        }
        private void MedarbejderLoginButtonExecute(object parameter)
        {
            MedarbejderLogin ml = new MedarbejderLogin();
            ml.Show();
        }



    }




}
