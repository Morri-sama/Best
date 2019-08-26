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
        public ICommand UpdateCommand { get; private set; }
        public ICommand NewNominationAdditionalFieldCommand { get; private set; }
        public ICommand AddSubnominationCommand { get; private set; }


        public NominationViewModel(IFrameNavigationService navigator, BestDbContext context)
        {
            MessengerInstance.Register<Nomination>(this, nomination => SetNomination(nomination));

            this.navigator = navigator;
            this.context = context;

            SaveCommand = new RelayCommand(Save);
            UpdateCommand = new RelayCommand(Update);
            NewNominationAdditionalFieldCommand = new RelayCommand(NewNominationAdditionalField);
            AddSubnominationCommand = new RelayCommand(AddSubnomination);

            //_context.NominationAdditionalFields.Load();
            //_context.Subnominations.Load();




            //if(_navigator.Parameter != null && _navigator.Parameter is Nomination)
            //{
            //    Nomination = _navigator.Parameter as Nomination;

            //    if(Nomination.NominationAdditionalFields == null)
            //    {
            //        Nomination.NominationAdditionalFields = new ObservableCollection<NominationAdditionalField>();
            //    }

            //    if(Nomination.Subnominations == null)
            //    {
            //        Nomination.Subnominations = new ObservableCollection<Subnomination>();
            //    }
            //}
            //else

            if(Nomination == null)
            {
                Nomination = new Nomination();
                Nomination.Subnominations = new ObservableCollection<Subnomination>();
                Nomination.NominationAdditionalFields = new ObservableCollection<NominationAdditionalField>();
            }




            //NominationAdditionalFields = new ObservableCollection<NominationAdditionalField>(_context.NominationAdditionalFields.Local);
            //Subnominations = new ObservableCollection<Subnomination>(_context.Subnominations.Local);
        }

        private void AddSubnomination()
        {
            Nomination.Subnominations.Add(new Subnomination());
        }

        private void NewNominationAdditionalField()
        {
            Nomination.NominationAdditionalFields.Add(new NominationAdditionalField());
        }

        private void Save()
        {
            context.Nominations.Add(Nomination);

            context.SaveChanges();
        }

        private void Update()
        {
            context.Nominations.Update(Nomination);

            context.SaveChanges();
        }

        private void SetNomination(Nomination nomination)
        {
            Nomination = nomination;
        }
    }
}
