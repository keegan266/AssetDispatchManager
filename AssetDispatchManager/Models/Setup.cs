using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetDispatchManager.Models
{
    public class Setup
    {
        #region Private Setup Variables
        private int setupID;
        private int addressID;
        private int equipmentID;
        private string doctorFirstName;
        private string doctroLastName;
        private ushort roomNumber;
        private string image;
        private string setUpDescription;
        #endregion

        #region Public Setup GetterSetters
        public int SetupID { get => setupID; set => setupID = value; }
        public int AddressID { get => addressID; set => addressID = value; }
        public int EquipmentID { get => equipmentID; set => equipmentID = value; }
        public string DoctorFirstName { get => doctorFirstName; set => doctorFirstName = value; }
        public string DoctroLastName { get => doctroLastName; set => doctroLastName = value; }
        public ushort RoomNumber { get => roomNumber; set => roomNumber = value; }
        public string Image { get => image; set => image = value; }
        public string SetUpDescription { get => setUpDescription; set => setUpDescription = value; }
        #endregion

        #region Public Setup Constructors
        public Setup(int setupID, int addressID, int equipmentID, string doctorFirstName, string doctroLastName, ushort roomNumber, string image, string setUpDescription)
        {
            SetupID = setupID;
            AddressID = addressID;
            EquipmentID = equipmentID;
            DoctorFirstName = doctorFirstName;
            DoctroLastName = doctroLastName;
            RoomNumber = roomNumber;
            Image = image;
            SetUpDescription = setUpDescription;
        } 
        #endregion
    }
}
