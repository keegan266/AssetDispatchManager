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
    [RoutePrefix("api/OnCallTechs")]
    public class OnCallTechsController : ApiController
    {
        private DataAdapter _Connector;
        public OnCallTechsController() { _Connector = new DataAdapter(); }
        public IEnumerable<OnCallTechs> Get()
        {
            List<OnCallTechs> onCallTechs = new List<OnCallTechs>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM OnCallTechs;", _Connector.database);
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
                                    newOnCallTechs.TechPrimaryID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechSecondaryID":
                                    newOnCallTechs.TechSecondaryID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechTertiaryID":
                                    newOnCallTechs.TechTertiaryID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechAvailable":
                                    newOnCallTechs.TechAvailable = byte.Parse(DataReader.GetValue(i).ToString());
                                    break;

                            }
                        }
                        onCallTechs.Add(newOnCallTechs);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return onCallTechs;
        } //connects to server, runs query Select * from OnCallTechs and returns a list of OnCallTechs objects
        public IEnumerable<OnCallTechs> Get(string id)
        {
            List<OnCallTechs> onCallTechs = new List<OnCallTechs>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM OnCallTechs WHERE OnCallTechID = {id};", _Connector.database);
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
                                    newOnCallTechs.TechPrimaryID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechSecondaryID":
                                    newOnCallTechs.TechSecondaryID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechTertiaryID":
                                    newOnCallTechs.TechTertiaryID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "TechAvailable":
                                    newOnCallTechs.TechAvailable = byte.Parse(DataReader.GetValue(i).ToString());
                                    break;

                            }
                        }
                        onCallTechs.Add(newOnCallTechs);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return onCallTechs;
        }
        public NegotiatedContentResult<string> Post([FromBody] OnCallTechs onCallTechs)
        {
            if (_Connector.SanatizeCheck(onCallTechs.Info()))
            {
                _Connector.Connect();
                string command = $"INSERT INTO OnCallTechs(TechPrimaryID, TechSecondaryID, TechTertiaryID, TechAvailable) VALUES({onCallTechs.Info()})";
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
