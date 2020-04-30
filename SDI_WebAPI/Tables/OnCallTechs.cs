using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class OnCallTechs
    {
        #region Private OnCallTechs Variables
        private int onCallTechID;
        private int techPrimaryID;
        private int techSecondaryID;
        private int techTertiaryID;
        private byte techAvailable;
        #endregion

        #region Public OnCallTechs GetterSetters
        public int OnCallTechID { get => onCallTechID; set => onCallTechID = value; }
        public int TechPrimaryID { get => techPrimaryID; set => techPrimaryID = value; }
        public int TechSecondaryID { get => techSecondaryID; set => techSecondaryID = value; }
        public int TechTertiaryID { get => techTertiaryID; set => techTertiaryID = value; }
        public byte TechAvailable { get => techAvailable; set => techAvailable = value; }
        #endregion

        #region Public OnCallTechs Constructors
        public OnCallTechs(int onCallTechID, int techPrimaryID, int techSecondaryID, int techTertiaryID, byte techAvailable)
        {
            OnCallTechID = onCallTechID;
            TechPrimaryID = techPrimaryID;
            TechSecondaryID = techSecondaryID;
            TechTertiaryID = techTertiaryID;
            TechAvailable = techAvailable;
        }

        public OnCallTechs()
        {
            OnCallTechID = 0;
            TechPrimaryID = 0;
            TechSecondaryID = 0;
            TechTertiaryID = 0;
            TechAvailable = 0;
        }
        #endregion

        public string Info()
        {
            string _tech = string.Empty;
            _ = (TechPrimaryID == 0 ? _tech += "0," : _tech += $"'{TechPrimaryID.ToString()}',");
            _ = (TechSecondaryID == 0 ? _tech += "0," : _tech += $"'{TechSecondaryID.ToString()}',");
            _ = (TechTertiaryID == 0 ? _tech += "0," : _tech += $"'{TechTertiaryID.ToString()}',");
            _ = (TechAvailable == 0 ? _tech += "0" : _tech += $"'{TechAvailable.ToString()}'");
            return _tech;
        }
    }
}
