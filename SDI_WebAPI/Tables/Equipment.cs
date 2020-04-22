using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebAPI.Tables
{
    public class Equipment
    {
        #region Private Equipment Variables
        private int equipmentID;
        private int laserID;
        private int phacoID;
        private int scopeID;
        private int vanID;
        #endregion

        #region Public Equipment GetterSetters
        public int EquipmentID { get => equipmentID; set => equipmentID = value; }
        public int LaserID { get => laserID; set => laserID = value; }
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
    }
}
