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
        private int _id;
        private string _name;
        private int _priority; 
        #endregion


        [Key]
        public int      Id       { get { return _id; }       set { Notify(ref _id, value, "Id"); } }
        public string   Name     { get { return _name; }     set { Notify(ref _name, value, "Name"); } }
        public int      Priority { get { return _priority; } set { Notify(ref _priority, value, "Priority"); } }


        public virtual ObservableCollection<Subnomination> Subnominations { get; set; }
        public virtual ObservableCollection<NominationAdditionalField> NominationAdditionalFields { get; set; }
    }
}
