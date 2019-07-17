using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Subnomination
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Nomination")]
        public int NominationId { get; set; }
        public Nomination Nomination { get; set; }
    }
}
