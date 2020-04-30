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
    [RoutePrefix("api/Laser")]
    public class LaserController : ApiController
    {
        private DataAdapter _Connector;
        public LaserController() { _Connector = new DataAdapter(); }
        public IEnumerable<Laser> Get()
        {
            List<Laser> lasers = new List<Laser>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Lens;", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Laser newLaser = new Laser();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "LenseID":
                                    newLaser.LaserID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "LenseName":
                                    newLaser.LaserName = (string)DataReader.GetValue(i);
                                    break;
                                case "Brand":
                                    newLaser.Brand = (string)DataReader.GetValue(i);
                                    break;
                                case "Model":
                                    newLaser.Model = (string)DataReader.GetValue(i);
                                    break;
                                case "IsActive":
                                    newLaser.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        lasers.Add(newLaser);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return lasers;
        } //connects to server, runs query Select * from Laser and returns a list of Laser objects
        public IEnumerable<Laser> Get(string id)
        {
            List<Laser> lasers = new List<Laser>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM Lens WHERE LaserID={id};", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Laser newLaser = new Laser();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "LenseID":
                                    newLaser.LaserID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "LenseName":
                                    newLaser.LaserName = (string)DataReader.GetValue(i);
                                    break;
                                case "Brand":
                                    newLaser.Brand = (string)DataReader.GetValue(i);
                                    break;
                                case "Model":
                                    newLaser.Model = (string)DataReader.GetValue(i);
                                    break;
                                case "IsActive":
                                    newLaser.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        lasers.Add(newLaser);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return lasers;
        }
        public NegotiatedContentResult<string> Post([FromBody] Laser laser)
        {
            if (_Connector.SanatizeCheck(laser.Info()))
            {
                _Connector.Connect();
                string command = $"INSERT INTO Laser(LaserName, Brand, Model, IsActive) VALUES({laser.Info()})";
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
