using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BestApp.ViewModels.Grades
{
    public class GradeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private GradeViewModel()
        {
            this.context = new BestDbContext();
            this.PropertyChanged += GradeViewModel_PropertyChanged;

            Grade = new Grade();

            SaveCommand = new RelayCommand(Save);
            BackCommand = new RelayCommand(Back);
        }

        public GradeViewModel (IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;
        }

        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;

        private Grade grade;
        public Grade Grade
        {
            get => grade;
            set=> Notify(ref grade, value, "Grade");
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

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
