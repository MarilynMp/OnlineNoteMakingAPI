using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineNoteMakingApp.DataAccess
{
    public interface IDataContext
    {
        MySqlConnection GetConnection();
    }
}
