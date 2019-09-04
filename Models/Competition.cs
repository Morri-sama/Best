using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Competition : PropertyChangedBase
    {
        #region Fields
        private int id;
        private string name;
        private string city;
        private DateTime date;
        private bool isClosed;
        private int diplomaNumber;
        private int diplomaNumberDigits;
        private ObservableCollection<Application> applications;
        #endregion

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get => id;
            set => Notify(ref id, value);
        }

        [Required]
        public string Name
        {
            get => name;
            set => Notify(ref name, value);
        }

        [Required]
        public string City
        {
            get => city;
            set => Notify(ref city, value);
        }

        [Required]
        public DateTime Date
        {
            get => date;
            set => Notify(ref date, value);
        }

        public bool IsClosed
        {
            get => isClosed;
            set => Notify(ref isClosed, value);
        }

        [Required]
        public int DiplomaNumber
        {
            get => diplomaNumber;
            set => Notify(ref diplomaNumber, value);
        }

        [Required]
        public int DiplomaNumberDigits
        {
            get => diplomaNumberDigits;
            set => Notify(ref diplomaNumberDigits, value);
        }

        [NotMapped]
        public string CityDate { get => City + " " + Date.ToString("dd.MM.yyyy"); }

        public virtual ObservableCollection<Application> Applications
        {
            get => applications;
            set => Notify(ref applications, value);
        }
    }
}
