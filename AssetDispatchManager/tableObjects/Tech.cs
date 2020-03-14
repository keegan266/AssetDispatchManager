using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetDispatchManager.tableObjects
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
        private string isWorking;
        #endregion

        #region Public Tech GetterSetters
        public int TechID { get => techID; set => techID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobRole { get => jobRole; set => jobRole = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string IsWorking { get => isWorking; set => isWorking = value; }
        #endregion

        #region Public Tech Constructors
        public Tech(int techID, string firstName, string lastName, string jobRole, string email, string phoneNumber, string isWorking)
        {
            TechID = techID;
            FirstName = firstName;
            LastName = lastName;
            JobRole = jobRole;
            Email = email;
            PhoneNumber = phoneNumber;
            IsWorking = isWorking;
        }
        #endregion
    }
}
