using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebAPI.Providers;
using SDI_WebAPI.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Phaco")]
    public class PhacoController : ApiController
    {
        private DataAdapter _Connector;
        public PhacoController() { _Connector = new DataAdapter(); }
        public IEnumerable<Phaco> Get()
        {
            List<Phaco> phacos = new List<Phaco>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Scope;", _Connector.database);
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
            _Connector.Disconnect();
            return phacos;
        } //connects to server, runs query Select * from Phaco and returns a list of Phaco objects
    }
}
