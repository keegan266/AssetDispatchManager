using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;
using System.Net;
using System.Web.Http.Results;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Lens")]
    public class LensController : ApiController
    {
        private DataAdapter _Connector;
        public LensController() { _Connector = new DataAdapter(); }
        public IEnumerable<Lens> Get()
        {
            List<Lens> lens = new List<Lens>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Lens;", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Lens newLens = new Lens();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "LenseID":
                                    newLens.LenseID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "LenseName":
                                    newLens.LensName = (string)DataReader.GetValue(i);
                                    break;
                                case "IsActive":
                                    newLens.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        lens.Add(newLens);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return lens;
        } //connects to server, runs query Select * from Lens and returns a list of Lens objects
        public IEnumerable<Lens> Get(string id)
        {
            List<Lens> lens = new List<Lens>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM Lens WHERE LensID={id};", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Lens newLens = new Lens();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "LenseID":
                                    newLens.LenseID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "LenseName":
                                    newLens.LensName = (string)DataReader.GetValue(i);
                                    break;
                                case "IsActive":
                                    newLens.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        lens.Add(newLens);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return lens;
        }
        public NegotiatedContentResult<string> Post([FromBody] Lens lens)
        {
            if (_Connector.SanatizeCheck(lens.Info()))
            {
                _Connector.Connect();
                string command = $"INSERT INTO LensCart(LensName, IsActive) VALUES({lens.Info()})";
                MySqlCommand execute = new MySqlCommand(command, _Connector.database);
                _Connector.Disconnect();
                return Content(HttpStatusCode.OK, "");
            }
            else
            {
                return Content(HttpStatusCode.Unauthorized, "Anti-Sql Injection Check failed");
            }
        }
    }
}
