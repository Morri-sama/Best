﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class NominationAdditionalField : PropertyChangedBase
    {
        private int id;
        private string name;
        private bool isRequired;
        private bool isPrinted;

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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                Notify(ref name, value, "Name");
            }
        }

        [Required]
        public bool IsRequired
        {
            get
            {
                return isRequired;
            }
            set
            {
                Notify(ref isRequired, value, "IsRequired");
            }
        }

        [Required]
        public bool IsPrinted
        {
            get
            {
                return isPrinted;
            }
            set
            {
                Notify(ref isPrinted, value, "IsPrinted");
            }
        }


        [ForeignKey("Nomination")]
        public int NominationId { get; set; }
        public virtual Nomination Nomination { get; set; }
    }
}
