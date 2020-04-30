using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Laser
    {
        #region Private Laser Variables
        private int laserID;
        private string laserName;
        private string brand;
        private string model;
        private bool isActive;
        #endregion

        #region Public Laser GetterSetters
        public int LaserID { get => laserID; set => laserID = value; }
        public string LaserName { get => laserName; set => laserName = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        #endregion

        #region Public Laser Constructors
        public Laser(int laserID, string laserName, string brand, string model, bool isActive)
        {
            LaserID = laserID;
            LaserName = laserName;
            Brand = brand;
            Model = model;
            IsActive = isActive;
        }

        public Laser()
        {
            LaserID = 0;
            LaserName = "Default LaserName";
            Brand = "Default Brand";
            Model = "Default Model";
            IsActive = false;
        }
        #endregion
        public string Info()
        {
            string _van = string.Empty;
            _ = (LaserName == "" ? _van += "null," : _van += $"'{LaserName.ToString()}',");
            _ = (Brand == "" ? _van += "null," : _van += $"'{Brand.ToString()}',");
            _ = (Model == "" ? _van += "null," : _van += $"'{Model.ToString()}',");
            _ = (IsActive == true ? _van += "TRUE" : _van += $"FALSE");
            return _van;
        }
    }
}
