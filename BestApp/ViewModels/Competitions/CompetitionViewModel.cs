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

namespace BestApp.ViewModels.Competitions
{
    public class CompetitionViewModel : ViewModelBase
    {
        private CompetitionViewModel()
        {
            context = new BestDbContext();

            Competition = new Competition()
            {
                BreakTimes = new ObservableCollection<BreakTime>()
            };

            SaveCommand = new RelayCommand(Save);
            BackCommand = new RelayCommand(Back);
        }

        public CompetitionViewModel(IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;
        }

        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;

        private void AddBreakTime()
        {

        }

        private void Save()
        {
            navigator.GoBack();
        }

        private void Back()
        {
            navigator.GoBack();
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        private Competition competition;
        public Competition Competition
        {
            get => competition;
            set
            {
                context.Competitions.Local.Clear();
                context.Competitions.Attach(value);
                context.Entry(value).Collection(b => b.BreakTimes).Load();

                Notify(ref competition, value);
            }
        }
    }
}
