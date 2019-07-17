using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class NominationAdditionalField : PropertyChangedBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public bool IsPrinted { get; set; }

        [ForeignKey("Nomination")]
        public int NominationId { get; set; }
        public Nomination Nomination { get; set; }
    }
}
