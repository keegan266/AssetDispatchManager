using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebAPI.Tables
{
    public class Appointment
    {
        #region Private Appointment Variables
        private int appointmentID;
        private int customerID;
        private DateTime dateTimeStart;
        private DateTime dateTimeEnd;
        private DateTime shipDate;
        private bool isActive;
        #endregion

        #region Public Appointment GetterSetters
        public int AppointmentID { get => appointmentID; set => appointmentID = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public DateTime DateTimeStart { get => dateTimeStart; set => dateTimeStart = value; }
        public DateTime DateTimeEnd { get => dateTimeEnd; set => dateTimeEnd = value; }
        public DateTime ShipDate { get => shipDate; set => shipDate = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        #endregion

        #region Public Appointment Constructors
        public Appointment(int appointmentID, int customerID, DateTime dateTimeStart, DateTime dateTimeEnd, DateTime shipDate, bool isActive)
        {
            AppointmentID = appointmentID;
            CustomerID = customerID;
            DateTimeStart = dateTimeStart;
            DateTimeEnd = dateTimeEnd;
            ShipDate = shipDate;
            IsActive = isActive;
        }

        public Appointment()
        {
            AppointmentID = 0;
            CustomerID = 0;
            DateTimeStart = new DateTime();
            DateTimeEnd = new DateTime();
            ShipDate = new DateTime();
            IsActive = false;
        }
        #endregion
    }
}
