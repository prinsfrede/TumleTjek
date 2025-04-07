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
using System.Windows.Shapes;
using TumleTjek.ViewModel;

namespace TumleTjek.View
{
    /// <summary>
    /// Interaction logic for CreateChild.xaml
    /// </summary>
    public partial class CreateChild : Window
    {
        CreateChildViewModel ccvm;
        public CreateChild()
        {
            ccvm = new CreateChildViewModel();
            InitializeComponent();
            this.DataContext = ccvm;
        }
    }
}
