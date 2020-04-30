using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Equipment
    {
        #region Private Equipment Variables
        private int equipmentID;
        private int laserID;
        private int lensID;
        private int phacoID;
        private int scopeID;
        private int vanID;
        #endregion

        #region Public Equipment GetterSetters
        public int EquipmentID { get => equipmentID; set => equipmentID = value; }
        public int LaserID { get => laserID; set => laserID = value; }
        public int LensID { get => lensID; set => lensID=value; }
        public int PhacoID { get => phacoID; set => phacoID = value; }
        public int ScopeID { get => scopeID; set => scopeID = value; }
        public int VanID { get => vanID; set => vanID = value; }
        #endregion

        #region Public Equipment Constructors
        public Equipment(int equipmentID, int laserID, int phacoID, int scopeID, int vanID)
        {
            EquipmentID = equipmentID;
            LaserID = laserID;
            PhacoID = phacoID;
            ScopeID = scopeID;
            VanID = vanID;
        }

        public Equipment()
        {
            EquipmentID = 0;
            LaserID = 0;
            PhacoID = 0;
            ScopeID = 0;
            VanID = 0;
        }
        #endregion
        public string Info()
        {
            string _tech = string.Empty;
            _ = (LaserID == 0 ? _tech += "0," : _tech += $"'{LaserID.ToString()}',");
            _ = (LensID == 0 ? _tech += "0," : _tech += $"'{LensID.ToString()}',");
            _ = (PhacoID == 0 ? _tech += "0," : _tech += $"'{PhacoID.ToString()}',");
            _ = (ScopeID == 0 ? _tech += "0," : _tech += $"'{ScopeID.ToString()}',");
            _ = (VanID == 0 ? _tech += "0" : _tech += $"'{VanID.ToString()}'");
            return _tech;
        }
    }
}
