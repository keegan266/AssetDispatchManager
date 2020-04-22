using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetDispatchManager.tableObjects
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
        public string LenseName { get => lenseName; set => lenseName = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        #endregion

        #region Public Lens Constructors
        public Lens(int lenseID, string lenseName, bool isActive)
        {
            LenseID = lenseID;
            LenseName = lenseName;
            IsActive = isActive;
        }
        #endregion
    }
}
