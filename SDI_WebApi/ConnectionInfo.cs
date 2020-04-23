using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDI_WebApi
{
    public class ConnectionInfo
    {
        public string ConnectString() 
        {
            return "server=localhost;Database=sdi_db;uid=root;pwd=Demigod@12;";
        }
    }
}