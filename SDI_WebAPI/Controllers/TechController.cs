using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Tech")]
    public class TechController : ApiController
    {
        private DataAdapter _Connector;
        public TechController() { _Connector = new DataAdapter(); }
        public IEnumerable<Tech> Get()
        {
            List<Tech> techs = new List<Tech>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Tech;", _Connector.database);
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
            _Connector.Disconnect();
            return techs;
        } //connects to server, runs query Select * from Tech and returns a list of Tech objects
    }
}
