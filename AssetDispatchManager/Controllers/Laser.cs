using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetDispatchManager.Controllers
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
        #endregion
    }
}
