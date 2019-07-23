using BestApp.Data;
using BestApp.Reports.Diploma;
using BestApp.Services.Navigation;
using BestApp.Services.Printing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Printing;
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
            PrintDiplomasCommand = new RelayCommand(PrintDiplomas);
        }


        private readonly IFrameNavigationService _navigator;
        private readonly BestDbContext _context;
        private ObservableCollection<Contest> _contests;
        private IList<Competition> _competitions;
        private Contest _selectedContest;
        private string _selectedPrinter;


        public List<string> Printers { get; set; }

        public string SelectedPrinter
        {
            get
            {
                return _selectedPrinter;
            }
            set
            {
                if(_selectedPrinter != value)
                {
                    _selectedPrinter = value;
                    RaisePropertyChanged("SelectedPrinter");
                }
            }
        }

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
        public ICommand PrintDiplomasCommand { get; private set; }

        private void DisplayApplications(Competition competition)
        {
            Contests = new ObservableCollection<Contest>(_context.Contests.Include(a => a.Application).Where(c => c.Application.Competition.Id == competition.Id));
        }

        private void PrintDiplomas()
        {
            if (Contests == null)
                return;

            List<LocalReport> reports = new List<LocalReport>();

            foreach(Contest contest in Contests)
            {
                var diplomaVm = new DiplomaViewModel()
                {
                    AgeCategory = "10 лет",
                    City = contest.Application.City ?? "",
                    Composition = contest.Composition ?? "",
                    ParticipantFullName = contest.Application.ParticipantFullName ?? "",
                    Subnomination = "Вокальное творчество"
                };


                LocalReport localReport = new LocalReport();
                localReport.DataSources.Add(new ReportDataSource("DataSetMain", new List<DiplomaViewModel>() { diplomaVm }));
                localReport.ReportEmbeddedResource = "BestApp.Reports.Diploma.Diploma.rdlc";

                reports.Add(localReport);
            }



            ReportPrinting reportPrinting = new ReportPrinting(reports);
            reportPrinting.Print();

        }

        private void DisplayReport(Contest contest)
        {

        }
    }
}
