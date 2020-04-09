﻿using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebAPI.Providers;
using SDI_WebAPI.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Van")]
    public class VanController : ApiController
    {
        private DataAdapter _Connector;
        public VanController() { _Connector = new DataAdapter(); }
        public IEnumerable<Van> Get()
        {
            List<Van> vans = new List<Van>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Van;", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Van newVan = new Van();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "VanID":
                                    newVan.VanID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "Brand":
                                    newVan.Brand = (string)DataReader.GetValue(i);
                                    break;
                                case "Model":
                                    newVan.Model = (string)DataReader.GetValue(i);
                                    break;
                                case "Length":
                                    newVan.Length = (string)DataReader.GetValue(i);
                                    break;
                                case "Height":
                                    newVan.Height = (string)DataReader.GetValue(i);
                                    break;
                                case "InUse":
                                    newVan.InUse = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        vans.Add(newVan);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return vans;
        } //connects to server, runs query Select * from Van and returns a list of Van objects
    }
}
