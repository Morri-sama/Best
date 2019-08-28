using BestApp.Models;
using BestApp.Services.Navigation;
using BestApp.Views.Competitions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService navigator;

        public ICommand DisplayCompetitionsCommand { get; private set; }
        public ICommand DisplayNominationsCommand { get; private set; }
        public ICommand DisplayApplicationsCommand { get; private set; }
        public ICommand DisplaySettingsCommand { get; private set; }

        public List<MenuItem> MenuItems { get; private set; }

        public MainViewModel(IFrameNavigationService navigator)
        {
            this.navigator = navigator;

            DisplayCompetitionsCommand = new RelayCommand(DisplayCompetitions);
            DisplayNominationsCommand = new RelayCommand(DisplayNominations);
            DisplayApplicationsCommand = new RelayCommand(DisplayApplications);
            DisplaySettingsCommand = new RelayCommand(DisplaySettings);

            MenuItems = new List<MenuItem>
            {
                new MenuItem("Конкурсы", PackIconKind.City, DisplayCompetitionsCommand),
                new MenuItem("Заявки", PackIconKind.FileDocument, DisplayApplicationsCommand),
                new MenuItem("Номинации", PackIconKind.FileMusic, DisplayNominationsCommand),
                new MenuItem("Настройки", PackIconKind.Settings, DisplaySettingsCommand)
            };
        }

        private void DisplaySettings()
        {
            navigator.NavigateTo("Settings");
        }

        private void DisplayApplications()
        {
            navigator.NavigateTo("Applications");
        }

        private void DisplayNominations()
        {
            navigator.NavigateTo("Nominations");
        }

        private void DisplayCompetitions()
        {
            navigator.NavigateTo("Competitions");
        }

        private void Close()
        {

        }

    }
}
