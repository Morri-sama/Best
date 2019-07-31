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



        private List<Grade> _grades;
        private readonly ApplicationsViewModel _applicationsViewModel;

        public List<Grade> Grades
        {
            get
            {
                return _grades;
            }
            set
            {
                _grades = value;
                RaisePropertyChanged("Grades");
            }
        }


        public Contest Contest { get; set; }

        public ICommand AcceptCommand { get; private set; }

        public GradeDialogViewModel(Contest contest, ApplicationsViewModel applicationsViewModel)
        {
            _applicationsViewModel = applicationsViewModel;


            Contest = contest;
            using (var context = new BestDbContext())
            {
                Grades = context.Grades.ToList();
            }

            AcceptCommand = new RelayCommand(Accept);
        }

        private void Accept()
        {
            using (var context = new BestDbContext())
            {
                var x = context.Contests.Where(d => d.Id == Contest.Id).FirstOrDefault();
                x.GradeId = Contest.GradeId;
                context.Contests.Update(x);
                context.SaveChanges();
            }
            _applicationsViewModel.IsOpen = false;
        }



    }
}
