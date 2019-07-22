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
        private readonly IFrameNavigationService _navigator;

        public ICommand DisplayCompetitionsCommand { get; private set; }
        public ICommand DisplayNominationsCommand { get; private set; }
        public ICommand DisplayApplicationsCommand { get; private set; }
        public ICommand DisplaySettingsCommand { get; private set; }

        public List<MenuItem> MenuItems { get; private set; }

        public MainViewModel(IFrameNavigationService navigator)
        {
            _navigator = navigator;

            DisplayCompetitionsCommand = new RelayCommand(DisplayCompetitions);
            DisplayNominationsCommand = new RelayCommand(DisplayNominations);
            DisplayApplicationsCommand = new RelayCommand(DisplayApplications);
            DisplaySettingsCommand = new RelayCommand(DisplaySettings);

            MenuItems = new List<MenuItem>();

            MenuItems.Add(new MenuItem("Конкурсы", PackIconKind.City, DisplayCompetitionsCommand));
            MenuItems.Add(new MenuItem("Заявки", PackIconKind.FileDocument, DisplayApplicationsCommand));
            MenuItems.Add(new MenuItem("Номинации", PackIconKind.FileMusic, DisplayNominationsCommand));
            MenuItems.Add(new MenuItem("Настройки", PackIconKind.Settings, DisplaySettingsCommand));
        }

        private void DisplaySettings()
        {
            _navigator.NavigateTo("Settings");
        }

        private void DisplayApplications()
        {
            _navigator.NavigateTo("Applications");
        }

        private void DisplayNominations()
        {
            _navigator.NavigateTo("Nominations");
        }

        private void DisplayCompetitions()
        {
            _navigator.NavigateTo("Competitions");
        }

        private void Close()
        {

        }

    }
}
