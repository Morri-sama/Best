using BestApp.Data;
using BestApp.Services.Navigation;
using BestApp.Views.Reporting;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
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
        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;
        private ObservableCollection<Nomination> nominations;

        public ObservableCollection<Nomination> Nominations
        {
            get
            {
                return this.nominations;
            }
            private set
            {
                this.nominations = value;
                RaisePropertyChanged("Nominations");
            }
        }

        public ICommand NewNominationCommand { get; private set; }
        public ICommand OpenNominationCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public NominationsViewModel(IFrameNavigationService navigator, BestDbContext context)
        {
            this.navigator = navigator;
            this.context = context;

            this.context.Nominations.Load();

            Nominations = this.context.Nominations.Local.ToObservableCollection();

            NewNominationCommand = new RelayCommand(NewNomination);
            OpenNominationCommand = new RelayCommand<Nomination>(OpenNomination);
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand<Nomination>(Delete);
        }

        private void Delete(Nomination nomination)
        {
            this.context.Nominations.Remove(nomination);
            this.context.SaveChanges();
        }

        private void Refresh()
        {
            this.context.Nominations.Load();
        }

        private void OpenNomination(Nomination nomination)
        {
            
            MessengerInstance.Send(nomination);
            this.navigator.NavigateTo("EditNomination", nomination);
        }

        private void NewNomination()
        {
            this.navigator.NavigateTo("NewNomination");

            //ReportViewerWindow reportViewerWindow = new ReportViewerWindow();
            //reportViewerWindow.ShowDialog();
        }
    }
}
