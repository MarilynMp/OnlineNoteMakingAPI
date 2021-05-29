using MySql.Data.MySqlClient;
using OnlineNoteMakingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.DataAccess
{
    public class DataContext : IDataContext
    {
        public string ConnectionString { get; set; }

        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
