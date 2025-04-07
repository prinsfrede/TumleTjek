using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TumleTjek.ViewModel;

namespace TumleTjek.View
{
    /// <summary>
    /// Interaction logic for ChildrenList.xaml
    /// </summary>
    public partial class ChildrenList : Page
    {
        ChildrenListViewModel clvm;
        public ChildrenList()
        {
            clvm = new ChildrenListViewModel();
            InitializeComponent();
            this.DataContext = clvm;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = Application.Current.MainWindow;
            this.Visibility = Visibility.Hidden;


            MainWindow.Visibility = Visibility.Visible;


        }
    }
}
