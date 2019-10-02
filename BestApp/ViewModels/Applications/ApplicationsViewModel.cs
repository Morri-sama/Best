using BestApp.Data;
using BestApp.Reports.Diploma;
using BestApp.Services.Navigation;
using BestApp.Services.Printing;
using BestApp.Views.Applications;
using BestApp.Views.Reporting;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MaterialDesignThemes.Wpf;
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
        public ApplicationsViewModel(IFrameNavigationService navigator)
        {
            this.navigator = navigator;


            this.context = new BestDbContext();

            Competitions = context.Competitions.Where(c => c.IsClosed == false).OrderBy(o => o.Date).ToList();

            Printers = new List<string>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                Printers.Add(printer);
            }

            DisplayApplicationsCommand = new RelayCommand<Competition>(DisplayApplications);
            DisplayReportCommand = new RelayCommand<Contest>(DisplayReport);
            PrintDiplomasCommand = new RelayCommand(PrintDiplomas);
            SetGradeCommand = new RelayCommand<Contest>(SetGrade);
            RefreshCommand = new RelayCommand(Refresh);
        }

        private void Refresh()
        {
            
        }

        private async void SetGrade(Contest contest)
        {
            var view = new GradeDialogUserControl()
            {
                DataContext = new GradeDialogViewModel(contest, this)
            };

            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;
        private ObservableCollection<Contest> _contests;
        private IList<Competition> _competitions;
        private Contest selectedContest;
        private string _selectedPrinter;


        private bool isOpen;
        public bool IsOpen
        {
            get => isOpen;
            set => Notify(ref isOpen, value);
        }

        public List<string> Printers { get; set; }

        public string SelectedPrinter
        {
            get
            {
                return _selectedPrinter;
            }
            set
            {
                if (_selectedPrinter != value)
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
            get => selectedContest;
            set => Notify(ref selectedContest, value);
        }

        public ICommand DisplayApplicationsCommand { get; private set; }
        public ICommand DisplayReportCommand { get; private set; }
        public ICommand PrintDiplomasCommand { get; private set; }
        public ICommand SetGradeCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        private void DisplayApplications(Competition competition)
        {
            context.Applications.Local.Clear();
            context.Applications.Where(c => c.Competition.Id == competition.Id).Load();

            Contests = new ObservableCollection<Contest>(context.Contests.Include(a => a.Application).ThenInclude(p => p.AgeCategory).Include(t=>t.Application.Teacher).ThenInclude(q=>q.TeacherType).Include(d => d.Grade).Include(l => l.Subnomination).ThenInclude(x => x.Nomination).Where(c => c.Application.Competition.Id == competition.Id));

            
        }

        private void PrintDiplomas()
        {
            if (Contests == null)
                return;

            List<LocalReport> reports = new List<LocalReport>();

            foreach (Contest contest in Contests)
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
                localReport.ReportEmbeddedResource = "BestApp.Reports.Diploma.Diploma2.rdlc";

                reports.Add(localReport);
            }



            ReportPrinting reportPrinting = new ReportPrinting(reports);
            reportPrinting.Print();

            //ReportPrinting2 reportPrinting = new ReportPrinting2(reports);
            //reportPrinting.Print();

        }

        private void DisplayReport(Contest contest)
        {
            DiplomaViewModel diplomaViewModel = new DiplomaViewModel
            {
                Grade = contest.Grade.Name,
                TeacherType = contest.Application.Teacher.TeacherType.Name,
                AgeCategory = contest.Application.AgeCategory.Name,
                City = contest.Application.City,
                Composition = contest.Composition,
                Subnomination = contest.Subnomination.Name,
                ParticipantFullName = contest.Application.ParticipantFullName,
                TeacherName = contest.Application.Teacher.FullName
            };

            ReportViewerWindow reportViewerWindow = new ReportViewerWindow(diplomaViewModel);
            reportViewerWindow.ShowDialog();
        }
    }
}
