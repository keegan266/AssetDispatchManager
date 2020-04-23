using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Scope")]
    public class ScopeController : ApiController
    {
        private DataAdapter _Connector;
        public ScopeController() { _Connector = new DataAdapter(); }
        public IEnumerable<Scope> Get()
        {
            List<Scope> scopes = new List<Scope>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Scope;", _Connector.database);
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
            _Connector.Disconnect();
            return scopes;
        } //connects to server, runs query Select * from Scope and returns a list of Scope objects
    }
}
