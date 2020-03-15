using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetDispatchManager.tableObjects
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
        #endregion
    }
}
