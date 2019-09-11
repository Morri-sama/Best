using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class NominationAdditionalFieldValueOption : PropertyChangedBase
    {
        private int id;
        private string value;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                Notify(ref id, value, "Id");
            }
        }

        [Required]
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                Notify(ref this.value, value);
            }
        }

        [ForeignKey("NominationAdditinalField")]
        public int NominationAdditionalFieldId { get; set; }
        public NominationAdditionalField NominationAdditionalField { get; set; }
    }
}
