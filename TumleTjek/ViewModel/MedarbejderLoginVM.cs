using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TumleTjek.TechnicalServices;
using TumleTjek.View;

namespace TumleTjek.ViewModel
{
    public class MedarbejderLoginVM
    {


        public ICommand LoginButton { get; }


        public MedarbejderLoginVM()
        {
            LoginButton = new RelayCommand(LoginButtonExecute);
        }

        public void LoginButtonExecute(object parameter)
        {
            List<Window> windowsToClose = new List<Window>();
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MedarbejderLogin || window is MainWindow)
                {
                    windowsToClose.Add(window);
                }
            }
            MedarbejderWindow maw = new MedarbejderWindow();
            maw.Show();
            foreach (Window window in windowsToClose)
            {
                window.Close();
            }
        }
    }
}
