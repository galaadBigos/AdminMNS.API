using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace AdminMNS.API.Domain.Services
{
	public static class Database
	{
        public static string ConnectionString { get; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdminMNS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection DbConnection { get; } = new SqlConnection(ConnectionString);
    }
}
