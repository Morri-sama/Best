using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Nominations
{
    public class NominationsViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService _navigator;
        private readonly BestDbContext _context;
        private ObservableCollection<Nomination> _nominations;

        public ObservableCollection<Nomination> Nominations
        {
            get
            {
                return _nominations;
            }
            private set
            {
                _nominations = value;
                RaisePropertyChanged("Nominations");
            }
        }

        public ICommand NewNominationCommand { get; private set; }
        public ICommand OpenNominationCommand { get; private set; }

        public NominationsViewModel(IFrameNavigationService navigator, BestDbContext context)
        {
            _navigator = navigator;
            _context = context;

            Nominations = new ObservableCollection<Nomination>(_context.Nominations);

            NewNominationCommand = new RelayCommand(NewNomination);
            OpenNominationCommand = new RelayCommand<Nomination>(OpenNomination);
        }

        private void OpenNomination(Nomination nomination)
        {
            MessengerInstance.Send(nomination);
            _navigator.NavigateTo("NewNomination", nomination);
        }

        private void NewNomination()
        {
            _navigator.NavigateTo("NewNomination");
        }
    }
}
