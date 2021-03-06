﻿using System;
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
        public IEnumerable<Appointment> Get(string id)
        {
            List<Appointment> appointments = new List<Appointment>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM Appointment WHERE AppointmentID = {id};", _Connector.database);
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
        }
        public IEnumerable<Appointment> Get(string Month, string Year)
        {
            List<Appointment> appointments = new List<Appointment>();
            _Connector.Connect();
            MySqlCommand execute = new MySqlCommand($"SELECT * FROM Appointment WHERE YEAR(DateTimeStart) = {Year} AND MONTH(DateTimeStart) = {Month};", _Connector.database);
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
        }

        public NegotiatedContentResult<string> Post([FromBody]Appointment appointment)
        {
            if (_Connector.SanatizeCheck(appointment.Info()))
            {
                _Connector.Connect();
                string command = $"INSERT INTO Appointment(CustomerID, DateTimeStart, DateTimeEnd, ShipDate, EquipmentCheckedin) VALUES({appointment.Info()})";
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
