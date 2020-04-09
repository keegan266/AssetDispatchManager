using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebAPI.Providers;
using SDI_WebAPI.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Address")]
    public class AddressController : ApiController
    {
        private DataAdapter _Connector;
        public AddressController() { _Connector = new DataAdapter(); }
        public IEnumerable<Address> Get()
        {
            List<Address> address = new List<Address>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Address;", _Connector.database);
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
            _Connector.Disconnect();
            return address;
        }

        //public void Post([FromBody]string value)
        //{
        //    _Connector.Connect();
        //    string command = $"INSERT INTO Address() VALUES({value})";
        //    MySqlCommand execute = new MySqlCommand(command, _Connector.database);
        //    _Connector.Disconnect();
        //}
    }
    
}
