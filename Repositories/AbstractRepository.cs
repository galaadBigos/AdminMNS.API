using AdminMNS.API.Abstractions;
using System.Data;

namespace AdminMNS.API.Repository
{
	public abstract class AbstractRepository
	{
		protected readonly IDbConnection _dbConnection;

		protected AbstractRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}
	}
}
