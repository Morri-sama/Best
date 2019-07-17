using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class AgeCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
    }
}
