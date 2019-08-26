using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Subnomination : PropertyChangedBase
    {
        private int id;
        private string name;

        [Key]
        public int Id { get { return id; } set { Notify(ref id, value, "Id"); } }
        public string Name { get { return name; } set { Notify(ref name, value, "Name"); } }

        [ForeignKey("Nomination")]
        public int NominationId { get; set; }
        public Nomination Nomination { get; set; }
    }
}
