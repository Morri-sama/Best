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
            BackCommand = new RelayCommand(Back);

            AddNominationAdditionalFieldCommand = new RelayCommand(AddNominationAdditionalField);
            DeleteNominationAdditionalFieldCommand = new RelayCommand<NominationAdditionalField>(DeleteNominationAdditionalField);

            AddNominationAdditionalFieldValueOptionCommand = new RelayCommand<NominationAdditionalField>(AddNominationAdditionalFieldValueOption);
            DeleteNominationAdditionalFieldValueOptionCommand = new RelayCommand<NominationAdditionalFieldValueOption>(DeleteNominationAdditionalFieldValueOption);

            AddSubnominationCommand = new RelayCommand(AddSubnomination);
            DeleteSubnominationCommand = new RelayCommand<Subnomination>(DeleteSubnomination);
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
        public ICommand BackCommand { get; private set; }

        public ICommand AddNominationAdditionalFieldCommand { get; private set; }
        public ICommand DeleteNominationAdditionalFieldCommand { get; private set; }

        public ICommand AddNominationAdditionalFieldValueOptionCommand { get; private set; }
        public ICommand DeleteNominationAdditionalFieldValueOptionCommand { get; private set; }

        public ICommand AddSubnominationCommand { get; private set; }
        public ICommand DeleteSubnominationCommand { get; private set; }


        private void NominationViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Nomination":
                    {
                        this.context.Nominations.Local.Clear();
                        this.context.Attach(Nomination);

                        this.context.Entry(Nomination).Collection(r => r.NominationAdditionalFields).Query().Include(w=>w.NominationAdditionalFieldValueOptions).Load();
                        this.context.Entry(Nomination).Collection(r => r.Subnominations).Load();

                    }
                    break;
            }
        }

        private void AddSubnomination()
        {
            Nomination.Subnominations.Add(new Subnomination());
        }

        private void DeleteSubnomination(Subnomination subnomination)
        {
            Nomination.Subnominations.Remove(subnomination);
        }

        private void AddNominationAdditionalField()
        {
            Nomination.NominationAdditionalFields.Add(new NominationAdditionalField());
        }

        private void DeleteNominationAdditionalField(NominationAdditionalField nominationAdditionalField)
        {
            Nomination.NominationAdditionalFields.Remove(nominationAdditionalField);
        }

        private void AddNominationAdditionalFieldValueOption(NominationAdditionalField nominationAdditionalField)
        {
            nominationAdditionalField.NominationAdditionalFieldValueOptions.Add(new NominationAdditionalFieldValueOption());
        }

        private void DeleteNominationAdditionalFieldValueOption(NominationAdditionalFieldValueOption nominationAdditionalFieldValueOption)
        {
            Nomination.NominationAdditionalFields.Where(i => i.Id == nominationAdditionalFieldValueOption.NominationAdditionalFieldId).FirstOrDefault().NominationAdditionalFieldValueOptions.Remove(nominationAdditionalFieldValueOption);
        }

        private void Save()
        {
            for (int i = 0; i < Nomination.NominationAdditionalFields.Count; i++)
            {
                if (String.IsNullOrEmpty(Nomination.NominationAdditionalFields[i].Name))
                {
                    Nomination.NominationAdditionalFields.RemoveAt(i);
                }
            }

            for (int i = 0; i < Nomination.Subnominations.Count; i++)
            {
                if (String.IsNullOrEmpty(Nomination.Subnominations[i].Name))
                {
                    Nomination.Subnominations.RemoveAt(i);
                }
            }

            foreach(var item in Nomination.NominationAdditionalFields)
            {
                for (int i = 0; i < item.NominationAdditionalFieldValueOptions.Count; i++)
                {
                    if (String.IsNullOrEmpty(item.NominationAdditionalFieldValueOptions[i].Value))
                    {
                        item.NominationAdditionalFieldValueOptions.RemoveAt(i);
                    }
                }
            }
            

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
