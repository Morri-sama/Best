using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        

        public string ParticipantFullName { get; set; }
        public string ParticipantPhoneNumber { get; set; }
        public string ParticipantEmail { get; set; }
        public string City { get; set; }

        public virtual List<Contest> Contests { get; set; }

        [ForeignKey("Competition")]
        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }    

        [ForeignKey("AgeCategory")]
        public int AgeCategoryId { get; set; }
        public virtual AgeCategory AgeCategory { get; set; }
        
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


    }
}
