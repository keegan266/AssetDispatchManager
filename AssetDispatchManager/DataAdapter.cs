using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AssetDispatchManager
{
    public class DataAdapter
    {
        #region Private methods
        private MySqlConnection database;
        private string userID;
        private string userPassword;
        private string connectionString;
        #endregion

        public DataAdapter(string userName, string password)
        {
            userID = userName;
            userPassword = password;
            connectionString = "";
        }
    }
}
