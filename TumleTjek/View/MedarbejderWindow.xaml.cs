using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TumleTjek.ViewModel;
using TumleTjek.TechnicalServices;

namespace TumleTjek.View
{
    /// <summary>
    /// Interaction logic for MedarbejderWindow.xaml
    /// </summary>
    public partial class MedarbejderWindow : Window
    {
        MedarbejderViewModel mvvm; 
        public MedarbejderWindow()
        {
            mvvm = new MedarbejderViewModel();
            InitializeComponent();
            this.DataContext = mvvm;
        }

       
        
    }
}
