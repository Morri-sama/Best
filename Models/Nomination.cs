using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Nomination : PropertyChangedBase
    {
        private int id;
        private string name;
        private int priority;

        private ObservableCollection<Subnomination> subnominations;
        private ObservableCollection<NominationAdditionalField> nominationAdditionalFields;

        [Key]
        public int Id { get { return id; } set { Notify(ref id, value, "Id"); } }

        [Required]
        public string Name { get { return name; } set { Notify(ref name, value, "Name"); } }

        [Required]
        public int Priority { get { return priority; } set { Notify(ref priority, value, "Priority"); } }


        public virtual ObservableCollection<Subnomination> Subnominations
        {
            get => subnominations;
            set => Notify(ref subnominations, value, "Subnominations");
        }

        public virtual ObservableCollection<NominationAdditionalField> NominationAdditionalFields
        {
            get => nominationAdditionalFields;
            set => Notify(ref nominationAdditionalFields, value, "NominationAdditionalFields");
        }
    }
}
