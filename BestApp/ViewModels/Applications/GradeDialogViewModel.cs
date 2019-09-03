using BestApp.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Applications
{
    public class GradeDialogViewModel : ViewModelBase
    {
        public GradeDialogViewModel(Contest contest, ApplicationsViewModel applicationsViewModel)
        {
            this.applicationsViewModel = applicationsViewModel;


            Contest = contest;
            using (var context = new BestDbContext())
            {
                Grades = context.Grades.ToList();
            }

            AcceptCommand = new RelayCommand(Accept);
        }


        private List<Grade> grades;
        private readonly ApplicationsViewModel applicationsViewModel;

        public List<Grade> Grades
        {
            get
            {
                return grades;
            }
            set
            {
                grades = value;
                RaisePropertyChanged("Grades");
            }
        }


        public Contest Contest { get; set; }

        public ICommand AcceptCommand { get; private set; }

        

        private void Accept()
        {
            using (var context = new BestDbContext())
            {
                var x = context.Contests.Where(d => d.Id == Contest.Id).FirstOrDefault();
                x.GradeId = Contest.GradeId;
                context.Contests.Update(x);
                context.SaveChanges();
            }
            applicationsViewModel.IsOpen = false;
        }



    }
}
