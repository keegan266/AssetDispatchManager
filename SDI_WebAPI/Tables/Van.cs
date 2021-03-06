﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_WebApi.Tables
{
    public class Van
    {
        #region Private Van Variables
        private int vanID;
        private string brand;
        private string model;
        private string length;
        private string height;
        private bool inUse;
        #endregion

        #region Public Van GetterSetters
        public int VanID { get => vanID; set => vanID = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Length { get => length; set => length = value; }
        public string Height { get => height; set => height = value; }
        public bool InUse { get => inUse; set => inUse = value; }
        #endregion

        #region Public Van Constructors
        public Van(int vanID, string brand, string model, string length, string height, bool inUse)
        {
            VanID = vanID;
            Brand = brand;
            Model = model;
            Length = length;
            Height = height;
            InUse = inUse;
        }

        public Van()
        {
            VanID = 0;
            Brand = "Default Brand";
            Model = "Default Model";
            Length = "Default Lenght";
            Height = "Default Height";
            InUse = false;
        }
        #endregion

        public string Info()
        {
            string _van = string.Empty;
            _ = (Brand == "" ? _van += "null," : _van += $"'{Brand.ToString()}',");
            _ = (Model == "" ? _van += "null," : _van += $"'{Model.ToString()}',");
            _ = (Length == "" ? _van += "null," : _van += $"'{Length.ToString()}',");
            _ = (Height == "" ? _van += "null," : _van += $"'{Height.ToString()}',");
            _ = (InUse == true ? _van += "TRUE" : _van += $"FALSE");
            return _van;
        }
    }
}
