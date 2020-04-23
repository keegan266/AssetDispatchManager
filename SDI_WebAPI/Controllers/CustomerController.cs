using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private DataAdapter _Connector;
        public CustomerController() { _Connector = new DataAdapter(); }
        public IEnumerable<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Customer;", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Customer newCustomer = new Customer();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "CustomerID":
                                    newCustomer.CustomerID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "SetupID":
                                    newCustomer.SetupID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "OnCallTechsID":
                                    newCustomer.OnCallTechsID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;

                            }
                        }
                        customers.Add(newCustomer);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return customers;
        } //connects to server, runs query Select * from Customer and returns a list of Customer objects

        public IEnumerable<Customer> Get(string id)
        {
            List<Customer> customers = new List<Customer>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM Customer WHERE CustomerID = {id};", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Customer newCustomer = new Customer();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "CustomerID":
                                    newCustomer.CustomerID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "SetupID":
                                    newCustomer.SetupID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "OnCallTechsID":
                                    newCustomer.OnCallTechsID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;

                            }
                        }
                        customers.Add(newCustomer);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return customers;

        }
    }
