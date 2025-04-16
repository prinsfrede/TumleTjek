using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;
using TumleTjek.ViewModel;
using TumleTjek.Repo;
using System.Windows;

namespace TumleTjek.ViewModel
{
    public class ChildArrivalViewModel : BaseViewModel
    {

        public ICommand GoBackButton { get; }

        public ICommand TjekIndButton { get; }

        public ICommand TjekUdButton { get; }

        private readonly Child _OriginalChild;

        public string Name { get; }

        private string _details;

        public string Details
        {
            get => _details;
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged();
                }
            }
        }



        public bool IsMet { get; set; }

        public ChildArrivalViewModel(ChildViewModel selectedChild,  NavigationStore navigationStore)
        {
            _OriginalChild = selectedChild.Child;

            Name = selectedChild.Name;
            Details = selectedChild.Details;
            IsMet = selectedChild.IsMet == false;

            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new ChildrenListViewModel(navigationStore)));

            TjekIndButton = new RelayCommand(_ => CheckIn());
            TjekUdButton = new RelayCommand(_ => CheckOut());
        }

        private void CheckIn()
        {   
            IsMet = true;
            SaveChanges();
            MessageBox.Show($"Barnet {Name} er tjekket ind.", "Tjek Ind", MessageBoxButton.OK, MessageBoxImage.Information);
            Details = "";

        }

        private void CheckOut()
        {
            IsMet = false;
            SaveChanges();
            MessageBox.Show($"Barnet {Name} er tjekket ud.", "Tjek Ud", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveChanges()
        {
            _OriginalChild.IsMet = IsMet;
            _OriginalChild.Details = Details;

            var repo = new BarnRepo();

            repo.Update(_OriginalChild);
        }




    }
}
