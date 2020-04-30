using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Tech
    {
        #region Private Tech Variables
        private int techID;
        private string firstName;
        private string lastName;
        private string jobRole;
        private string email;
        private string phoneNumber;
        private bool isWorking;
        #endregion

        #region Public Tech GetterSetters
        public int TechID { get => techID; set => techID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobRole { get => jobRole; set => jobRole = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }
        #endregion

        #region Public Tech Constructors
        public Tech(int techID, string firstName, string lastName, string jobRole, string email, string phoneNumber, bool isWorking)
        {
            TechID = techID;
            FirstName = firstName;
            LastName = lastName;
            JobRole = jobRole;
            Email = email;
            PhoneNumber = phoneNumber;
            IsWorking = isWorking;
        }

        public Tech()
        {
            TechID = 0;
            FirstName = "Default FirstName";
            LastName = "Default LastName";
            JobRole = "Default JobRole";
            Email = "Default Email";
            PhoneNumber = "00000000000";
            IsWorking = isWorking;
        }
        #endregion

        public string Info()
        {
            string _tech = string.Empty;
            _ = (FirstName == "" ? _tech += "null," : _tech += $"'{FirstName.ToString()}',");
            _ = (LastName == "" ? _tech += "null," : _tech += $"'{LastName.ToString()}',");
            _ = (JobRole == "" ? _tech += "null," : _tech += $"'{JobRole.ToString()}',");
            _ = (Email == "" ? _tech += "null," : _tech += $"'{Email.ToString()}',");
            _ = (PhoneNumber == "" ? _tech += "null," : _tech += $"'{PhoneNumber.ToString()}',");
            _ = (IsWorking == true ? _tech += "TRUE" : _tech += $"FALSE");
            return _tech;
        }
    }
}
