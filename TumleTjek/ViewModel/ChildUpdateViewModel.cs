using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;

namespace TumleTjek.ViewModel
{
    public class ChildUpdateViewModel : BaseViewModel
    {
        public ICommand Update { get; }

        public ICommand RemoveChild { get; }

        public ICommand GoBackButton { get; }

        private readonly Child _OriginalChild;

        public string Name { get; }

        private int? _age;

        public int? Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _parentName;
        public string ParentName
        {
            get => _parentName;
            set
            {
                if (_parentName != value)
                {
                    _parentName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _parentPhoneNumber;
        public string ParentPhoneNumber
        {
            get => _parentPhoneNumber;
            set
            {
                if (_parentPhoneNumber != value)
                {
                    _parentPhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }






        public ChildUpdateViewModel(NavigationStore navigationStore, ChildViewModel selectedChild)
        {

            _OriginalChild = selectedChild.Child;
            Name = selectedChild.Name;
            Age = selectedChild.Age;
            ParentName = selectedChild.Parents.Name;
            ParentPhoneNumber = selectedChild.Parents.PhoneNumber;

            Update = new RelayCommand(_ => UpdateChild());
            RemoveChild = new RelayCommand(_ => RemoveChildFromDataBase());
            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new WorkerChildListViewModel(navigationStore)));
        }



        public void UpdateChild()
        {
            _OriginalChild.Age = Age;
            _OriginalChild.Parents.Name = ParentName;
            _OriginalChild.Parents.PhoneNumber = ParentPhoneNumber;
            var repo = new BarnRepo();
            MessageBox.Show($"Barnet {Name} er blevet opdateret.", "Opdater Barn", MessageBoxButton.OK, MessageBoxImage.Information);
            repo.Update(_OriginalChild);

        }

        public void RemoveChildFromDataBase()
        {
            var repo = new BarnRepo();
            repo.Remove(_OriginalChild.ChildID);

            MessageBox.Show($"Barnet {Name} er blevet fjernet.", "Fjern Barn", MessageBoxButton.OK, MessageBoxImage.Information);
            
            Age = null;
            ParentName = "";
            ParentPhoneNumber = "";

        }
    }
}
