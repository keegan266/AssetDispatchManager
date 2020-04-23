using System;
using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using SDI_WebApi.Providers;
using SDI_WebApi.Tables;

namespace SDI_WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        private DataAdapter _Connector;
        public AppointmentController() { _Connector = new DataAdapter(); }
        public IEnumerable<Appointment> Get()
        {
            List<Appointment> appointments = new List<Appointment>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand("SELECT * FROM Appointment;", _Connector.database);
            using (MySqlDataReader DataReader = execute.ExecuteReader())
            {
                do
                {
                    while (DataReader.Read())
                    {
                        Appointment newAppointment = new Appointment();
                        for (int i = 0; i < DataReader.FieldCount; i++)
                        {
                            switch (DataReader.GetName(i))
                            {
                                case "AppointmentID":
                                    newAppointment.AppointmentID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "CustomerID":
                                    newAppointment.CustomerID = int.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "DateTimeStart":
                                    newAppointment.DateTimeStart = DateTime.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "DateTimeEnd":
                                    newAppointment.DateTimeEnd = DateTime.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "ShipDate":
                                    newAppointment.ShipDate = DateTime.Parse(DataReader.GetValue(i).ToString());
                                    break;
                                case "IsActive":
                                    newAppointment.IsActive = (bool)DataReader.GetValue(i);
                                    break;

                            }
                        }
                        appointments.Add(newAppointment);
                    }
                } while (DataReader.NextResult());
            }
            execute.Dispose();
            _Connector.Disconnect();
            return appointments;
        } //connects to server, runs query Select * from Customer and returns a list of Customer objects
    }
}
