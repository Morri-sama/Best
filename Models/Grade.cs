using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Grade : PropertyChangedBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get => name;
            set => Notify(ref name, value);
        }

        public virtual ICollection<Contest> Contests { get; set; }
    }
}
