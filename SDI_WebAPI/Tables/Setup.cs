using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
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

        public Setup()
        {
            SetupID = 0;
            AddressID = 0;
            EquipmentID = 0;
            DoctorFirstName = "Default DoctorFirstName";
            DoctroLastName = "Default DoctorLastName";
            RoomNumber = 000;
            Image = "Default ImageUrl";
            SetUpDescription = "Default SetUpDescription";
        }
        #endregion

        public string Info()
        {
            string _addressInfo = string.Empty;
            _ = (AddressID == 0 ? _addressInfo += "null," : _addressInfo += $"'{AddressID.ToString()}',");
            _ = (EquipmentID == 0 ? _addressInfo += "null," : _addressInfo += $"'{EquipmentID.ToString()}',");
            _ = (DoctorFirstName == "" ? _addressInfo += "null," : _addressInfo += $"'{DoctorFirstName.ToString()}',");
            _ = (DoctroLastName == "" ? _addressInfo += "null," : _addressInfo += $"'{DoctroLastName.ToString()}',");
            _ = (RoomNumber == 0 ? _addressInfo += "null," : _addressInfo += $"'{RoomNumber.ToString()}',");
            _ = (Image == "" ? _addressInfo += "null," : _addressInfo += $"'{Image.ToString()},'");
            _ = (SetUpDescription == "" ? _addressInfo += "null" : _addressInfo += $"'{SetUpDescription.ToString()}'");
            return _addressInfo;
        }
    }
}
