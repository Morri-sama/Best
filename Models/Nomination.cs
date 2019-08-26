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
        #region Fields
        private int id;
        private string name;
        private int priority; 
        #endregion


        [Key]
        public int      Id       { get { return id; }       set { Notify(ref id, value, "Id"); } }
        public string   Name     { get { return name; }     set { Notify(ref name, value, "Name"); } }
        public int      Priority { get { return priority; } set { Notify(ref priority, value, "Priority"); } }


        public virtual ObservableCollection<Subnomination> Subnominations { get; set; }
        public virtual ObservableCollection<NominationAdditionalField> NominationAdditionalFields { get; set; }
    }
}
