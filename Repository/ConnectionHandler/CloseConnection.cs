using Microsoft.Data.SqlClient;

namespace Repository.ConnectionHandler
{
    public static class CloseConnection
    {
        public static void DisposeConnection()
        {
            SqlConnection.ClearAllPools();
        }
    }
}
