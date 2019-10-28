using System.Data.SqlClient;

namespace ComputerHorizon.Models
{
    public class DataBase
    {
        private static readonly string CONNECTION_STRING = @"Server=AMODIFIER;Database=AMODIFIER;Integrated Security=SSPI;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(CONNECTION_STRING);
        }
    }
}