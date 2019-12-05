using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class BreakTime : PropertyChangedBase
    {
        private int id;
        private DateTime start;
        private DateTime end;

        private int competitionId;
        private Competition competition;



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => id;
            set => Notify(ref id, value);
        }

        [Required]
        public DateTime Start
        {
            get => start;
            set => Notify(ref start, value);
        }

        [Required]
        public DateTime End
        {
            get => end;
            set => Notify(ref end, value);
        }

        [ForeignKey("Competition")]
        public int CompetitionId
        {
            get => competitionId;
            set => Notify(ref competitionId, value);
        }

        public virtual Competition Competition
        {
            get => competition;
            set => Notify(ref competition, value);
        }

    }
}
