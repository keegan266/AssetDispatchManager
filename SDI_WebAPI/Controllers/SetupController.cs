using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Setup")]
    public class SetupController : ApiController
    {
        private DataAdapter _Connector;
        public SetupController() { _Connector = new DataAdapter(); }
        public IEnumerable<Setup> Get()
        {
            List<Setup> setups = new List<Setup>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Setup;", _Connector.database);
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
            _Connector.Disconnect();
            return setups;
        } //connects to server, runs query Select * from Setup and returns a list of Setup objects
        public IEnumerable<Setup> Get(string id)
        {
            List<Setup> setups = new List<Setup>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM Setup WHERE SetuupID = {id};", _Connector.database);
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
            _Connector.Disconnect();
            return setups;
        }
    }
}
