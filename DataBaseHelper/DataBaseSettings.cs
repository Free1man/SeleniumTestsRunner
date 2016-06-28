using System;
using System.Configuration;

namespace DataBaseHelper
{
    internal class DataBaseSettings
    {
        public string DataBaseName { get; set; }
        public string PathToDataBase { get; set; }
        public string ConnectionString { get; set; }

        public DataBaseSettings()
        {
            Initialise();
        }

        private void Initialise()
        {
            DataBaseName = ConfigurationManager.AppSettings["DataBaseName"];
            if (string.IsNullOrEmpty(DataBaseName))
            {
                throw new InvalidOperationException("DataBaseName must be set in Configuration");
            }

            PathToDataBase = ConfigurationManager.AppSettings["PathToDataBase"];
            if (string.IsNullOrEmpty(PathToDataBase))
            {
                throw new InvalidOperationException("PathToDataBase must be set in Configuration");
            }

            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new InvalidOperationException("ConnectionString must be set in Configuration");
            }
        }
    }
}
