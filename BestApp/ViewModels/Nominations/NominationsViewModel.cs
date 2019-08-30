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
        private NominationsViewModel()
        {
            this.context = new BestDbContext();

            this.context.Nominations.Load();

            Nominations = this.context.Nominations.Local.ToObservableCollection();

            NewNominationCommand = new RelayCommand(NewNomination);
            OpenNominationCommand = new RelayCommand<Nomination>(OpenNomination);
            RefreshCommand = new RelayCommand(Refresh);
            DeleteCommand = new RelayCommand<Nomination>(Delete);
        }

        public NominationsViewModel(IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;            
        }




        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;
        private ObservableCollection<Nomination> nominations;


        public ICommand NewNominationCommand { get; private set; }
        public ICommand OpenNominationCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
               

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
            this.navigator.NavigateTo("Nomination", "Nomination", nomination);
        }

        private void NewNomination()
        {
            this.navigator.NavigateTo("Nomination");

            //ReportViewerWindow reportViewerWindow = new ReportViewerWindow();
            //reportViewerWindow.ShowDialog();
        }
    }
}
