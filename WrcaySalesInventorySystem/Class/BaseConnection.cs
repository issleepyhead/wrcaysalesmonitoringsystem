using System.Data;
using System.Data.SqlClient;
using WrcaySalesInventorySystem.Properties;

namespace WrcaySalesInventorySystem.Class
{
    public class BaseConnection
    {
        private SqlConnection? sqlConnection;
        public SqlConnection getConnection()
        {
            sqlConnection = new(Settings.Default.wrcaydbConnectionString);
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
           
            return sqlConnection;
        }
    }
}
