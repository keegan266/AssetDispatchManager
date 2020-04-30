using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Lens
    {
        #region Private Lens Variables
        private int lenseID;
        private string lenseName;
        private bool isActive;
        #endregion

        #region Public Lens GetterSetters
        public int LenseID { get => lenseID; set => lenseID = value; }
        public string LensName { get => lenseName; set => lenseName = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        #endregion

        #region Public Lens Constructors
        public Lens(int lenseID, string lensName, bool isActive)
        {
            LenseID = lenseID;
            LensName = lenseName;
            IsActive = isActive;
        }

        public Lens()
        {
            LenseID = 0;
            LensName = "Default Lensname";
            IsActive = false;
        }
        #endregion

        public string Info()
        {
            string _van = string.Empty;
            _ = (LensName == "" ? _van += "null," : _van += $"'{LensName.ToString()}',");
            _ = (IsActive == true ? _van += "TRUE" : _van += $"FALSE");
            return _van;
        }
    }
}
