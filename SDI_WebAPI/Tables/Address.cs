using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Address
    {
        #region Private Address Variables
        private int addressID;
        private string buildingName;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private string state;
        private string zipcode;
        #endregion

        #region Public Address GetterSetters
        public int AddressID { get => addressID; set => addressID = value; }
        public string BuildingName { get => buildingName; set => buildingName = value; }
        public string AddressLine1 { get => addressLine1; set => addressLine1 = value; }
        public string AddressLine2 { get => addressLine2; set => addressLine2 = value; }
        public string City { get => city; set => city = value; }
        public string State { get => state; set => state = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        #endregion

        #region Public Address Constructors
        public Address(int addressID, string buildingName, string addressLine1, string addressLine2, string city, string state, string zipcode1)
        {
            AddressID = addressID;
            BuildingName = buildingName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            State = state;
            zipcode = zipcode1;
        }

        public Address()
        {
            AddressID = 0;
            BuildingName = "Default Building Name";
            AddressLine1 = "Default Address Line 1";
            AddressLine2 = "Default Address Line 2";
            City = "Default City";
            State = "MO";
            Zipcode = "00000";
        }
        #endregion
    }
}
