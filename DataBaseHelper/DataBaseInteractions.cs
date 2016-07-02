using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace DataBaseHelper
{
    public class DataBaseInteractions
    {
        private DataBaseSettings dataBaseSettings;

        DataBaseInteractions()
        {
            dataBaseSettings = new DataBaseSettings();
        }

        private string CreateSqlStringRestoreDatabase()
        {
            var dataBaseName = dataBaseSettings.DataBaseName;
            var pathToDataBase = dataBaseSettings.PathToDataBase;
            var sqlString = $@"
            ALTER DATABASE { dataBaseName } SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE { dataBaseName }
            RESTORE DATABASE { dataBaseName }
            FROM DISK = '{ pathToDataBase }/{ dataBaseName }.bak'
            WITH REPLACE";

            return sqlString;
        }


        [SqlProcedure]
        private void ExcuteSqlQuery(string sqlQuery)
        {
            using (var connectionString = new SqlConnection(dataBaseSettings.ConnectionString))
            {
                var command = new SqlCommand
                {
                    CommandText = sqlQuery,
                    Connection = connectionString
                };
                connectionString.Open();
                command.ExecuteNonQuery();
                connectionString.Close();
            }
        }

        public void RestoreDB()
        {
            ExcuteSqlQuery(CreateSqlStringRestoreDatabase());
        }
    }
}

