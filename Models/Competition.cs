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
        private int lastDiplomaNumber;
        private ObservableCollection<Application> applications;
        private ObservableCollection<BreakTime> breakTimes;
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

        public int LastDiplomaNumber
        {
            get => lastDiplomaNumber;
            set => Notify(ref lastDiplomaNumber, value);
        }

        [NotMapped]
        public string CityDate { get => City + " " + Date.ToString("dd.MM.yyyy") + " " + Name; }

        public virtual ObservableCollection<Application> Applications
        {
            get => applications;
            set => Notify(ref applications, value);
        }

        public virtual ObservableCollection<BreakTime> BreakTimes
        {
            get => breakTimes;
            set => Notify(ref breakTimes, value);
        }
    }
}
