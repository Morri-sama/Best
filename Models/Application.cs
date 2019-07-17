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
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("ФИО или название коллектива")]
        public string ParticipantFullName { get; set; }
        [DisplayName("Номер телефона участника")]
        public string ParticipantPhoneNumber { get; set; }
        [DisplayName("Почта участника")]
        public string ParticipantEmail { get; set; }
        [DisplayName("Организация и город, которую представляет конкурсант")]
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
