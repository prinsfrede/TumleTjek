using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using TumleTjek.View;

namespace TumleTjek.ViewModel
{
    public class CreateChildViewModel: BaseViewModel
    {
        private string _name;
        private string _age;
        private string _forældreName;
        private string _forældrePhoneNumber;

        private BarnRepo childrepo = new BarnRepo();

        public ICommand AddChildButton { get; }
        public ICommand GoBackButton { get; }

        public CreateChildViewModel(NavigationStore navigationStore)
        {
            AddChildButton = new RelayCommand(AddChildButtonExecute);
            GoBackButton = new NavigateCommand(new Services.NavigationService(navigationStore, () => new MedarbejderViewModel(navigationStore)));

        }

        public string Name
        {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string ForældreName
        {
            get => _forældreName;
            set
            {
                _forældreName = value;
                OnPropertyChanged(nameof(ForældreName));
            }
        }

        public string ForældrePhoneNumber
        {
            get => _forældrePhoneNumber;
            set
            {
                _forældrePhoneNumber = value;
                OnPropertyChanged(nameof(ForældrePhoneNumber));
            }
        }

        public void AddChildButtonExecute(object parameter)
        {
          if (!int.TryParse(Age, out int ageint))
            {
                ageint = 0;
            }
          var newChild = new Child
          {
              Name = Name,
              Age = ageint,
              
              Parents = new Forældre
              {
                  Name = ForældreName,
                  PhoneNumber = ForældrePhoneNumber
              },
             
          };
            childrepo.Add(newChild);

            Name = string.Empty;
            Age = string.Empty;
            ForældreName = string.Empty;
            ForældrePhoneNumber = string.Empty;

            MessageBox.Show("Barn tilføjet");

        }
     


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
