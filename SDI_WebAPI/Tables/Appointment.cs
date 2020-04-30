using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
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

        public string Info()
        {
            string _addressInfo = string.Empty;
            _ = (CustomerID == 0 ? _addressInfo += "null," : _addressInfo += $"'{CustomerID.ToString()}',");
            _ = (DateTimeStart == new DateTime() ? _addressInfo += "null," : _addressInfo += $"'{DateTimeStart.ToString()}',");
            _ = (DateTimeEnd == new DateTime() ? _addressInfo += "null," : _addressInfo += $"'{DateTimeEnd.ToString()}',");
            _ = (ShipDate == new DateTime() ? _addressInfo += "null," : _addressInfo += $"'{ShipDate.ToString()}',");
            _ = (IsActive == true ? _addressInfo += "TRUE" : _addressInfo += $"FALSE");
            return _addressInfo;
        }
    }
}
