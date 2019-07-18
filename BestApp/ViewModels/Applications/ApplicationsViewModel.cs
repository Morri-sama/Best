using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Applications
{
    public class ApplicationsViewModel : ViewModelBase
    {
        public ApplicationsViewModel(IFrameNavigationService navigator, BestDbContext context)
        {
            _navigator = navigator;
            _context = context;

            Competitions = _context.Competitions.Where(c => c.IsClosed == false).OrderBy(o => o.Date).ToList();

            Printers = new List<string>();
            foreach(string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Printers.Add(printer);
            }

            DisplayApplicationsCommand = new RelayCommand<Competition>(DisplayApplications);
            DisplayReportCommand = new RelayCommand<Contest>(DisplayReport);
        }


        private readonly IFrameNavigationService _navigator;
        private readonly BestDbContext _context;
        private ObservableCollection<Contest> _contests;
        private IList<Competition> _competitions;
        private Contest _selectedContest;


        public List<string> Printers { get; set; }


        public IList<Competition> Competitions
        {
            get
            {
                return _competitions;
            }
            private set
            {
                _competitions = value;
                RaisePropertyChanged("Competitions");
            }
        }
        public ObservableCollection<Contest> Contests
        {
            get
            {
                return _contests;
            }
            private set
            {
                _contests = value;
                RaisePropertyChanged("Contests");
            }
        }

        public Contest SelectedContest
        {
            get
            {
                return _selectedContest;
            }
            set
            {
                _selectedContest = value;
                RaisePropertyChanged("SelectedContest");
            }
        }

        public ICommand DisplayApplicationsCommand { get; private set; }
        public ICommand DisplayReportCommand { get; private set; }

        private void DisplayApplications(Competition competition)
        {
            Contests = new ObservableCollection<Contest>(_context.Contests.Include(a => a.Application).Where(c => c.Application.Competition.Id == competition.Id));
        }

        

        private void DisplayReport(Contest contest)
        {

        }
    }
}
