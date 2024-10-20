using Npgsql;

namespace Delcars.Infra.Data.Postgre
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
