using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestApp.Reports.Diploma
{
    public class DiplomaViewModel
    {
        public int ContestId { get; set; }
        public int ApplicationId { get; set; }
        public int Priority { get; set; }
        public string AgeCategory { get; set; }
        public string ParticipantFullName { get; set; }
        public string Subnomination { get; set; }
        public string Composition { get; set; }
        public string TeacherName { get; set; }
        public string TeacherType { get; set; }
        public string City { get; set; }
        public string Grade { get; set; }
    }
}
