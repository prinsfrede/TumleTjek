using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.View;
using TumleTjek.ViewModel;
using TumleTjek.Services;
using TumleTjek.Model;
using ScottPlot;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using ScottPlot.WPF;

namespace TumleTjek.ViewModel
{
    public class AbsenceViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; }
        /*Her er constructor til grafen*/
        public WpfPlot PlotControl { get; } = new WpfPlot();
        public AbsenceViewModel () { Plot(); }

        public AbsenceViewModel(NavigationStore navigationStore)
        {
            GoBackCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => new MedarbejderViewModel(navigationStore)));
            Plot();
        }
        /*Her sættes data til grafen*/
        private void Plot()
        {
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            PlotControl.Plot.Add.Scatter(dataX, dataY);
            PlotControl.Refresh();
            PlotControl.Background = System.Windows.Media.Brushes.LightGray;

        }
       

    }
}
