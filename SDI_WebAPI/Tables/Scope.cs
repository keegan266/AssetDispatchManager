using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Scope
    {
        #region Private Scope Variables
        private int scopeID;
        private string scopeName;
        private string brand;
        private string model;
        private bool isActive;
        #endregion

        #region Public Scope GetterSetters
        public int ScopeID { get => scopeID; set => scopeID = value; }
        public string ScopeName { get => scopeName; set => scopeName = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        #endregion

        #region Public Scope Constructors
        public Scope(int scopeID, string scopeName, string brand, string model, bool isActive)
        {
            ScopeID = scopeID;
            ScopeName = scopeName;
            Brand = brand;
            Model = model;
            IsActive = isActive;
        }

        public Scope()
        {
            ScopeID = 0;
            ScopeName = "Default ScopeName";
            Brand = "Default Brand";
            Model = "Default Model";
            IsActive = false;
        }
        #endregion

        public string Info()
        {
            string _van = string.Empty;
            _ = (ScopeName == "" ? _van += "null," : _van += $"'{ScopeName.ToString()}',");
            _ = (Brand == "" ? _van += "null," : _van += $"'{Brand.ToString()}',");
            _ = (Model == "" ? _van += "null," : _van += $"'{Model.ToString()}',");
            _ = (IsActive == true ? _van += "TRUE" : _van += $"FALSE");
            return _van;
        }
    }
}
