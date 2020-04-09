using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebAPI.Providers;
using SDI_WebAPI.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Equipment")]
    public class EquipmentController : ApiController
    {
        private DataAdapter _Connector;
        public EquipmentController() { _Connector = new DataAdapter(); }
        public IEnumerable<Equipment> Get()
        {
            List<Equipment> equipment = new List<Equipment>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Equipment;", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Equipment newEquipment = new Equipment();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "EquipmentID":
                                    newEquipment.EquipmentID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "LaserID":
                                    newEquipment.LaserID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "PhacoID":
                                    newEquipment.PhacoID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "ScopeID":
                                    newEquipment.ScopeID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;

                            }
                        }
                        equipment.Add(newEquipment);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return equipment;
        } //connects to server, runs query Select * from Equipment and returns a list of Equipment objects
    }
}
