using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Competition : PropertyChangedBase
    {
        #region Fields
        private int _id;
        private string _city;
        private DateTime _date;
        private bool _isClosed;
        private int _diplomaNumber;
        #endregion

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get { return _id; } set { Notify(ref _id, value, "Id"); } }
        public string City { get { return _city; } set { Notify(ref _city, value, "City"); } }
        public DateTime Date { get { return _date; } set { Notify(ref _date, value, "Date"); } }
        public bool IsClosed { get { return _isClosed; } set { Notify(ref _isClosed, value, "IsClosed"); } }

        public int DiplomaNumber { get { return _diplomaNumber; } set { Notify(ref _diplomaNumber, value, "DiplomaNumber"); } }

        [NotMapped]
        public string CityDate { get => City + " " + Date.ToString("dd.MM.yyyy"); }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
