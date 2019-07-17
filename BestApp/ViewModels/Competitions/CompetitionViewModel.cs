using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Competitions
{
    public class CompetitionViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService _navigator;

        public Competition Competition { get; set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public CompetitionViewModel(IFrameNavigationService navigator)
        {
            _navigator = navigator;

            Competition = new Competition();

            SaveCommand = new RelayCommand(Save);
            BackCommand = new RelayCommand(Back);
        }

        private void Save()
        {
            using (var context = new BestDbContext())
            {
                context.Competitions.Add(Competition);
                context.SaveChanges();
            }

            _navigator.GoBack();
        }

        private void Back()
        {
            _navigator.GoBack();
        }
    }
}
