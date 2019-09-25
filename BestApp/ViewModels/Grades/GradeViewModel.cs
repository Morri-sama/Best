using BestApp.Data;
using BestApp.Services.Navigation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.ViewModels.Grades
{
    public class GradeViewModel : ViewModelBase
    {
        private GradeViewModel()
        {
            this.context = new BestDbContext();
            this.PropertyChanged += GradeViewModel_PropertyChanged;
        }


        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;

        private Grade grade;
        public Grade Grade
        {
            get => grade;
            set=> Notify(ref grade, value);
        }


        private void GradeViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Grade":
                    {
                        this.context.Grades.Local.Clear();
                        this.context.Attach(Grade);
                    }
                    break;
            }
        }

        private void Save()
        {
            this.context.SaveChanges();
            this.context.Dispose();

            navigator.GoBack();
        }

        private void Back()
        {
            this.context.Dispose();
            navigator.GoBack();
        }
    }
}
