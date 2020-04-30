using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Phaco
    {
        #region Private Phaco Variables
        private int phacoID;
        private string phacoName;
        private string brand;
        private string model;
        private bool isActive;
        #endregion

        #region Public Phaco GetterSetters
        public int PhacoID { get => phacoID; set => phacoID = value; }
        public string PhacoName { get => phacoName; set => phacoName = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        #endregion

        #region Public Phaco Constructors
        public Phaco(int phacoID, string phacoName, string brand, string model, bool isActive)
        {
            PhacoID = phacoID;
            PhacoName = phacoName;
            Brand = brand;
            Model = model;
            IsActive = isActive;
        }

        public Phaco()
        {
            PhacoID = 0;
            PhacoName = "Default PhacoName";
            Brand = "Default Brand";
            Model = "Default Model";
            IsActive = false;
        }
        #endregion

        public string Info()
        {
            string _van = string.Empty;
            _ = (PhacoName == "" ? _van += "null," : _van += $"'{PhacoName.ToString()}',");
            _ = (Brand == "" ? _van += "null," : _van += $"'{Brand.ToString()}',");
            _ = (Model == "" ? _van += "null," : _van += $"'{Model.ToString()}',");
            _ = (IsActive == true ? _van += "TRUE" : _van += $"FALSE");
            return _van;
        }
    }
}
