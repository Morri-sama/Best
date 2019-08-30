using BestApp.Data;
using BestApp.Services.Navigation;
using BestApp.ViewModels.Applications;
using BestApp.ViewModels.Competitions;
using BestApp.ViewModels.Nominations;
using BestApp.ViewModels.Settings;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<CompetitionsViewModel>();
            SimpleIoc.Default.Register<CompetitionViewModel>();

            SimpleIoc.Default.Register<NominationViewModel>();
            SimpleIoc.Default.Register<NominationsViewModel>();

            SimpleIoc.Default.Register<ApplicationsViewModel>();


            SimpleIoc.Default.Register<SettingsViewModel>();

            SetupNavigation();
        }

        public MainViewModel Main { get => ServiceLocator.Current.GetInstance<MainViewModel>(); }

        public CompetitionsViewModel CompetitionsViewModel { get => ServiceLocator.Current.GetInstance<CompetitionsViewModel>(); }
        public CompetitionViewModel CompetitionViewModel { get => ServiceLocator.Current.GetInstance<CompetitionViewModel>(); }

        public NominationsViewModel NominationsViewModel { get => ServiceLocator.Current.GetInstance<NominationsViewModel>(); }
        public NominationViewModel NominationViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstanceWithoutCaching<NominationViewModel>();
            }
        }


        public ApplicationsViewModel ApplicationsViewModel { get => ServiceLocator.Current.GetInstance<ApplicationsViewModel>(); }


        public SettingsViewModel SettingsViewModel { get => ServiceLocator.Current.GetInstance<SettingsViewModel>(); }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Competitions", new Uri("../Views/Competitions/CompetitionsPage.xaml", UriKind.Relative));
            navigationService.Configure("Competition", new Uri("../Views/Competitions/CompetitionPage.xaml", UriKind.Relative));

            navigationService.Configure("Nominations", new Uri("../Views/Nominations/NominationsPage.xaml", UriKind.Relative));
            navigationService.Configure("Nomination", new Uri("../Views/Nominations/NominationPage.xaml", UriKind.Relative));

            navigationService.Configure("Applications", new Uri("../Views/Applications/ApplicationsPage.xaml", UriKind.Relative));


            navigationService.Configure("Settings", new Uri("../Views/Settings/SettingsPage.xaml", UriKind.Relative));

            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
            SimpleIoc.Default.Register(() => new BestDbContext());
        }



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }


    }
}
