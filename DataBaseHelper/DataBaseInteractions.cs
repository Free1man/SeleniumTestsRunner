using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace DataBaseHelper
{
    public class DataBaseInteractions
    {
        private readonly DataBaseSettings _dataBaseSettings;

        private DataBaseInteractions()
        {
            _dataBaseSettings = new DataBaseSettings();
        }

        private string CreateSqlStringRestoreDatabase()
        {
            var dataBaseName = _dataBaseSettings.DataBaseName;
            var pathToDataBase = _dataBaseSettings.PathToDataBase;
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
            using (var connectionString = new SqlConnection(_dataBaseSettings.ConnectionString))
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

        public void RestoreDb()
        {
            ExcuteSqlQuery(CreateSqlStringRestoreDatabase());
        }
    }
}

