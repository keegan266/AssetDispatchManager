using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;

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
            _Connector.Disconnect();
            return onCallTechs;
        } //connects to server, runs query Select * from OnCallTechs and returns a list of OnCallTechs objects
    }
}
