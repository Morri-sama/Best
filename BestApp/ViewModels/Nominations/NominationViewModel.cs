using BestApp.Data;
using BestApp.Services.Navigation;
using GalaSoft.MvvmLight;
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

namespace BestApp.ViewModels.Nominations
{
    public class NominationViewModel : ViewModelBase
    {
        private NominationViewModel()
        {
            this.context = new BestDbContext();

            this.PropertyChanged += NominationViewModel_PropertyChanged;

            Nomination = new Nomination();

            SaveCommand = new RelayCommand(Save);
            AddNominationAdditionalFieldCommand = new RelayCommand(AddNominationAdditionalField);
            AddSubnominationCommand = new RelayCommand(AddSubnomination);
        }

        public NominationViewModel(IFrameNavigationService navigator) : this()
        {
            this.navigator = navigator;
        }


        private readonly IFrameNavigationService navigator;
        private readonly BestDbContext context;

        private Nomination nomination;
        public Nomination Nomination
        {
            get
            {
                return nomination;
            }
            set
            {
                nomination = value;
                RaisePropertyChanged("Nomination");
            }
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand AddNominationAdditionalFieldCommand { get; private set; }
        public ICommand AddSubnominationCommand { get; private set; }


        private void NominationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Nomination":
                    {
                        this.context.Nominations.Local.Clear();
                        this.context.Attach(Nomination);

                        this.context.Entry(Nomination).Collection(r => r.NominationAdditionalFields).Load();
                        this.context.Entry(Nomination).Collection(r => r.Subnominations).Load();
                    }
                    break;
            }
        }

        private void AddSubnomination()
        {
            if (Nomination.Subnominations == null)
            {
                Nomination.Subnominations = new ObservableCollection<Subnomination>();
            }

            Nomination.Subnominations.Add(new Subnomination());
        }

        private void AddNominationAdditionalField()
        {
            if (Nomination.NominationAdditionalFields == null)
            {
                Nomination.NominationAdditionalFields = new ObservableCollection<NominationAdditionalField>();
            }

            Nomination.NominationAdditionalFields.Add(new NominationAdditionalField());
        }

        private void Save()
        {
            context.SaveChanges();
        }
    }
}
