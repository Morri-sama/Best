using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Competitions
{
    public class CompetitionsViewModel : ViewModelBase
    {
        private CompetitionsViewModel()
        {
            this.context = new BestDbContext();
            this.context.Competitions.Where(o=>o.IsClosed == false).Load();

            Competitions = this.context.Competitions.Local.ToObservableCollection();

            NewCompetitionCommand = new RelayCommand(NewCompetition);
        }

        public CompetitionsViewModel(IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;          
        }

        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;

        public ICommand NewCompetitionCommand { get; private set; }

        private ObservableCollection<Competition> competitions;
        public ObservableCollection<Competition> Competitions
        {
            get
            {
                return competitions;
            }

            private set
            {
                competitions = value;
                RaisePropertyChanged("Competitions");
            }
        }


        private void NewCompetition()
        {
            navigator.NavigateTo("Competition");
        }
    }
}
