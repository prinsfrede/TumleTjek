﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TumleTjek.Model;
using TumleTjek.Repo;
using TumleTjek.Stores;
using TumleTjek.TechnicalServices;

namespace TumleTjek.ViewModel
{
    public class ChildrenListViewModel : BaseViewModel
    {
        public ICommand GoBackCommand { get; }


        private ChildViewModel _selectedChild;
        public ChildViewModel SelectedChild
        {
            get => _selectedChild;
            set
            {
                _selectedChild = value;
                OnPropertyChanged(nameof(SelectedChild));
            }
        }
        public ICommand ChildDoubleClickCommand { get; }

        private readonly NavigationStore _navigationStore;

        private ChildRepo childRepo = new ChildRepo();

        public ObservableCollection<ChildViewModel> ChildVM { get; set; }


        private string _searchText; // Searchbar - rr
        public string SearchText
        {
            get => SearchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    
                }
            }




        }
        public ChildrenListViewModel(NavigationStore navigationStore)
        {

            this._navigationStore = navigationStore;

            ChildVM = new ObservableCollection<ChildViewModel>();
            foreach (Child barn in childRepo.GetAll())
            {
                ChildVM.Add(new ChildViewModel(barn, barn.Name, barn.Age, barn.Details, barn.Parents, barn.IsMet));
            }
            GoBackCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => new HomeViewModel1(navigationStore)));
            ChildDoubleClickCommand = new NavigateCommand(new Services.NavigationService(navigationStore, () => new ChildArrivalViewModel(SelectedChild, navigationStore)));


        }
    }
}
