using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Contest
    {
        [Key]
        public int Id { get; set; }

        public string DiplomaNumber { get; set; }

        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        public int ApproximateTime { get; set; }
        public DateTime PerfomanceTime { get; set; }

        public string Composer { get; set; }
        public string Composition { get; set; }

        public string AdditionalInformation { get; set; }
        public int PeopleAmount { get; set; }

        [ForeignKey("Grade")]
        public int? GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        [ForeignKey("Nomination")]
        public int? NominationId { get; set; }
        public virtual Nomination Nomination { get; set; }

        [ForeignKey("Subnomination")]
        public int? SubnominationId { get; set; }
        public virtual Subnomination Subnomination { get; set; }

        public virtual ICollection<NominationAdditionalFieldValue> NominationAdditionalFieldValues { get; set; }
    }
}
