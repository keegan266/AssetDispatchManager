using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebAPI.Tables
{
    public class OnCallTechs
    {
        #region Private OnCallTechs Variables
        private int onCallTechID;
        private int TechPrimaryID;
        private int TechSecondaryID;
        private int TechTertiaryID;
        private byte TechAvailable;
        #endregion

        #region Public OnCallTechs GetterSetters
        public int OnCallTechID { get => onCallTechID; set => onCallTechID = value; }
        public int TechPrimaryID1 { get => TechPrimaryID; set => TechPrimaryID = value; }
        public int TechSecondaryID1 { get => TechSecondaryID; set => TechSecondaryID = value; }
        public int TechTertiaryID1 { get => TechTertiaryID; set => TechTertiaryID = value; }
        public byte TechAvailable1 { get => TechAvailable; set => TechAvailable = value; }
        #endregion

        #region Public OnCallTechs Constructors
        public OnCallTechs(int onCallTechID, int techPrimaryID1, int techSecondaryID1, int techTertiaryID1, byte techAvailable1)
        {
            OnCallTechID = onCallTechID;
            TechPrimaryID1 = techPrimaryID1;
            TechSecondaryID1 = techSecondaryID1;
            TechTertiaryID1 = techTertiaryID1;
            TechAvailable1 = techAvailable1;
        }

        public OnCallTechs()
        {
            OnCallTechID = 0;
            TechPrimaryID1 = 0;
            TechSecondaryID1 = 0;
            TechTertiaryID1 = 0;
            TechAvailable1 = 0;
        }
        #endregion
    }
}
