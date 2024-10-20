using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delcars.Infrastructure.Context
{
    public class DbConnection : IDisposable
    {
        public NpgsqlConnection Connection { get; set; }

        public DbConnection()
        {
            Connection = new NpgsqlConnection("Server=localhost;Port=5432;Database=del_cars;User Id=postgres;Password=1234");
            Connection.Open();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
