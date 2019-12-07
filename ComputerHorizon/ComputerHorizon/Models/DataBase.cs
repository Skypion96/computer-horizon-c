using System.Data.SqlClient;

namespace ComputerHorizon.Models
{
    public static class DataBase
    {
        //private static readonly string CONNECTION_STRING = @"Server=LAPTOP-58DH50DP;Database=Computer-Horizon;Integrated Security=SSPI;";
        private static readonly string CONNECTION_STRING = @"Server=VINCENT;Database=Computer-Horizon;Integrated Security=SSPI;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(CONNECTION_STRING);
        }
    }
}