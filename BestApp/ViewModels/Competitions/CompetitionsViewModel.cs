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
        private readonly IFrameNavigationService _navigator;
        private readonly BestDbContext _context;

        private ObservableCollection<Competition> _competitions;

        public ObservableCollection<Competition> Competitions
        {
            get
            {
                return _competitions;
            }

            private set
            {
                if (_competitions == value)
                {
                    return;
                }

                _competitions = value;
                RaisePropertyChanged("Competitions");
            }
        }

        public ICommand NewCompetitionCommand { get; private set; }

        public CompetitionsViewModel(IFrameNavigationService navigator, BestDbContext context)
        {
            _navigator = navigator;
            _context = context;

            NewCompetitionCommand = new RelayCommand(NewCompetition);

            Competitions = new ObservableCollection<Competition>(_context.Competitions.Include(c=>c.Applications).OrderBy(o => o.Date));
        }

        private void NewCompetition()
        {
            _navigator.NavigateTo("Competition");
        }
    }
}
