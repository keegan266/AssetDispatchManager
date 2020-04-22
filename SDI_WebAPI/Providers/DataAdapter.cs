using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace SDI_WebAPI.Providers
{
    public class DataAdapter
    {
        #region Private methods
        public MySqlConnection database;
        private string connectionString;
        #endregion

        public DataAdapter()
        {
            ConnectionInfo _connect = new ConnectionInfo();
            connectionString = _connect.ConnectString();
        }

        public void Connect()
        {
            database = new MySqlConnection();
            database.ConnectionString = connectionString;
            try
            {
                database.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection Error: " + e);
            }
        } //Connects to the Database ** Must be called in every function to start a connection request

        public void Disconnect()
        {
            try
            {
                database.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Dissonnection Error: " + e);
            }
        } //Disconnects from the database ** Must be called in every function to end a connection and free the server

    }
}