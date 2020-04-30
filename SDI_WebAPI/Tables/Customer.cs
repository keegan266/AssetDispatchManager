using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Customer
    {
        #region Private Customer Variables
        private int customerID;
        private int setupID;
        private int onCallTechsID;
        #endregion

        #region Public Customer GetterSetters
        public int CustomerID { get => customerID; set => customerID = value; }
        public int SetupID { get => setupID; set => setupID = value; }
        public int OnCallTechsID { get => onCallTechsID; set => onCallTechsID = value; }

        #endregion

        #region Public Customer Constructors
        public Customer(int customerID, int setupID, int onCallTechsID)
        {
            CustomerID = customerID;
            SetupID = setupID;
            OnCallTechsID = onCallTechsID;
        }

        public Customer()
        {
            CustomerID = 0;
            SetupID = 0;
            OnCallTechsID = 0;
        }
        #endregion
        public string Info()
        {
            string _addressInfo = string.Empty;
            _ = (SetupID == 0 ? _addressInfo += "null," : _addressInfo += $"'{SetupID.ToString()}',");
            _ = (OnCallTechsID == 0 ? _addressInfo += "null" : _addressInfo += $"'{OnCallTechsID.ToString()}'");
            return _addressInfo;
        }
    }
}
