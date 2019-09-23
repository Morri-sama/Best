using BestApp.Data;
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

        public GradesViewModel()
        {
            this.context = new BestDbContext();

            this.context.Grades.Load();
        }

        private readonly BestDbContext context;
        private ObservableCollection<Grade> grades;
        
        public ICommand NewGradeCommand { get; private set; }
        public ICommand OpenGradeCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public ObservableCollection<Grade> Grades
        {
            get => grades;
            set => Notify(ref grades, value);
        }


    }
}
