using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Grades
{
    public class GradesViewModel : ViewModelBase
    {
        private GradesViewModel()
        {
            this.context = new BestDbContext();

            this.context.Grades.Load();

            Grades = this.context.Grades.Local.ToObservableCollection();

            NewGradeCommand = new RelayCommand(NewGrade);
            OpenGradeCommand = new RelayCommand<Grade>(OpenGrade);
            RefreshCommand = new RelayCommand(Refresh);
        }

        public GradesViewModel(IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;
        }

        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;
        private ObservableCollection<Grade> grades;
        
        public ICommand NewGradeCommand { get; private set; }
        public ICommand OpenGradeCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        private void Refresh()
        {
            this.context.Grades.Load();
        }

        private void OpenGrade(Grade grade)
        {
            this.navigator.NavigateTo("Grade", "Grade", grade);
        }

        private void NewGrade()
        {
            throw new NotImplementedException();
        }


        public ObservableCollection<Grade> Grades
        {
            get => grades;
            set => Notify(ref grades, value);
        }


    }
}
