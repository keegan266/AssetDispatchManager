using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebAPI.Tables
{
    public class Customer
    {
        #region Private Customer Variables
        private int customerID;
        private int setupID;
        private int onCallTechsID;
        private int vanID;
        #endregion

        #region Public Customer GetterSetters
        public int CustomerID { get => customerID; set => customerID = value; }
        public int SetupID { get => setupID; set => setupID = value; }
        public int OnCallTechsID { get => onCallTechsID; set => onCallTechsID = value; }
        public int VanID { get => vanID; set => vanID = value; }
        #endregion

        #region Public Customer Constructors
        public Customer(int customerID, int setupID, int onCallTechsID, int vanID)
        {
            CustomerID = customerID;
            SetupID = setupID;
            OnCallTechsID = onCallTechsID;
            VanID = vanID;
        }

        public Customer()
        {
            CustomerID = 0;
            SetupID = 0;
            OnCallTechsID = 0;
            VanID = 0;
        }
        #endregion
    }
}
