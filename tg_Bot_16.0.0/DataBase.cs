using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace tg_Bot_16._0._0
{
    class DataBase
    {
        public SqlConnection sqlConnection;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sakurych\source\repos\tg_Bot\tg_Bot\tg_Bot_16.0.0\Database1.mdf;Integrated Security=True";
        public void ConnectSql()           
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}
