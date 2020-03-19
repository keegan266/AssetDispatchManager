using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AssetDispatchManager.tableObjects;

namespace AssetDispatchManager
{
    public class DataAdapter
    {
        #region Private methods
        private MySqlConnection database;
        private string userID;
        private string userPassword;
        private string connectionString;
        #endregion

        public DataAdapter(string userName, string password)
        {
            userID = userName;
            userPassword = password;
            connectionString = $"server=localhost;database=sdi_db;uid={userName};pwd={password};";
        }

        public void Connect()
        {
            database = new MySqlConnection();
            database.ConnectionString = connectionString;
            try
            {
                database.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Error: " + e);
            }
        } //Connects to the Database ** Must be called in every function to start a connection request

        public void Disconnect()
        {
            try
            {
                database.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Dissonnection Error: " + e);
            }
        } //Disconnects from the database ** Must be called in every function to end a connection and free the server
        public List<Address> GetAllAddresses()
        {
            List<Address> address = new List<Address>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Address;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Address newAddress = new Address();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "AddressID":
                                    newAddress.AddressID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "BuildingName":
                                    newAddress.BuildingName = (string)DataReader.GetValue(i);
                                    break;
                                case "AddressLine1":
                                    newAddress.AddressLine1 = (string)DataReader.GetValue(i);
                                    break;
                                case "AddressLine2":
                                    newAddress.AddressLine2 = (string)DataReader.GetValue(i);
                                    break;
                                case "City":
                                    newAddress.City = (string)DataReader.GetValue(i);
                                    break;
                                case "State":
                                    newAddress.State = (string)DataReader.GetValue(i);
                                    break;
                                case "Zipcode":
                                    newAddress.Zipcode = (string)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        address.Add(newAddress);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return address;
        } //connects to server, runs query Select * from Address and returns a list of address objects

        public List<Tech> GetAllTechs()
        {
            List<Tech> techs = new List<Tech>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Tech;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Tech newtech = new Tech();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "TechID":
                                    newtech.TechID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "FirstName":
                                    newtech.FirstName = (string)DataReader.GetValue(i);
                                    break;
                                case "LastName":
                                    newtech.LastName = (string)DataReader.GetValue(i);
                                    break;
                                case "JobRole":
                                    newtech.JobRole = (string)DataReader.GetValue(i);
                                    break;
                                case "Email":
                                    newtech.Email = (string)DataReader.GetValue(i);
                                    break;
                                case "PhoneNumber":
                                    newtech.PhoneNumber = (string)DataReader.GetValue(i);
                                    break;
                                case "IsWorking":
                                    newtech.IsWorking = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        techs.Add(newtech);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return techs;
        } //connects to server, runs query Select * from Tech and returns a list of Tech objects

        public List<Van> GetAllVans()
        {
            List<Van> vans = new List<Van>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Van;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Van newVan = new Van();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "VanID":
                                    newVan.VanID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "Brand":
                                    newVan.Brand = (string)DataReader.GetValue(i);
                                    break;
                                case "Model":
                                    newVan.Model = (string)DataReader.GetValue(i);
                                    break;
                                case "Length":
                                    newVan.Length = (string)DataReader.GetValue(i);
                                    break;
                                case "Height":
                                    newVan.Height = (string)DataReader.GetValue(i);
                                    break;
                                case "InUse":
                                    newVan.InUse = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        vans.Add(newVan);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return vans;
        } //connects to server, runs query Select * from Van and returns a list of Van objects

        public List<Setup> GetAllSetups()
        {
            List<Setup> setups = new List<Setup>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Setup;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Setup newSetup = new Setup();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "SetupID":
                                    newSetup.SetupID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "AddressID":
                                    newSetup.AddressID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "EquipmentID":
                                    newSetup.EquipmentID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "DoctorFirstName":
                                    newSetup.DoctorFirstName = (string)DataReader.GetValue(i);
                                    break;
                                case "DoctroLastName":
                                    newSetup.DoctroLastName = (string)DataReader.GetValue(i);
                                    break;
                                case "RoomNumber":
                                    newSetup.RoomNumber = ushort.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "Image":
                                    newSetup.Image = (string)DataReader.GetValue(i);
                                    break;
                                case "SetUpDescription":
                                    newSetup.SetUpDescription = (string)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        setups.Add(newSetup);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return setups;
        } //connects to server, runs query Select * from Setup and returns a list of Setup objects

        public List<Scope> GetAllScopes()
        {
            List<Scope> scopes = new List<Scope>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Scope;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Scope newScope = new Scope();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "ScopeID":
                                    newScope.ScopeID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "Brand":
                                    newScope.Brand = (string)DataReader.GetValue(i);
                                    break;
                                case "Model":
                                    newScope.Model = (string)DataReader.GetValue(i);
                                    break;
                                case "ScopeName":
                                    newScope.ScopeName = (string)DataReader.GetValue(i);
                                    break;
                                case "IsActive":
                                    newScope.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        scopes.Add(newScope);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return scopes;
        } //connects to server, runs query Select * from Scope and returns a list of Scope objects

        public List<Phaco> GetAllPhacos()
        {
            List<Phaco> phacos = new List<Phaco>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Scope;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Phaco newPhaco = new Phaco();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "PhacoID":
                                    newPhaco.PhacoID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "Brand":
                                    newPhaco.Brand = (string)DataReader.GetValue(i);
                                    break;
                                case "Model":
                                    newPhaco.Model = (string)DataReader.GetValue(i);
                                    break;
                                case "PhacoName":
                                    newPhaco.PhacoName = (string)DataReader.GetValue(i);
                                    break;
                                case "IsActive":
                                    newPhaco.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        phacos.Add(newPhaco);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return phacos;
        } //connects to server, runs query Select * from Phaco and returns a list of Phaco objects

        public List<OnCallTechs> GetAllOnCallTechs()
        {
            List<OnCallTechs> onCallTechs = new List<OnCallTechs>();
            Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM OnCallTechs;", database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        OnCallTechs newOnCallTechs = new OnCallTechs();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "OnCallTechID":
                                    newOnCallTechs.OnCallTechID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechPrimaryID":
                                    newOnCallTechs.TechPrimaryID1 = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechSecondaryID":
                                    newOnCallTechs.TechSecondaryID1 = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechTertiaryID":
                                    newOnCallTechs.TechTertiaryID1 = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechAvailable":
                                    newOnCallTechs.TechAvailable1 = byte.Parse(DataReader.GetValue(i).ToString());
                                    break;

                            }
                        }
                        onCallTechs.Add(newOnCallTechs);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            Disconnect();
            return onCallTechs;
        } //connects to server, runs query Select * from OnCallTechs and returns a list of OnCallTechs objects
    }
}
