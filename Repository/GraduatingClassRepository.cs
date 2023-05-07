using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Models;
using System.Data;

namespace AdminMNS.API.Repository
{
	public class GraduatingClassRepository : IGraduatingClassRepository
	{
		private readonly IDbConnection _dbConnection;

		public GraduatingClassRepository(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public IEnumerable<GraduatingClass>? GetGraduatingClasses()
		{
			List<GraduatingClass> result = new List<GraduatingClass>();

			string query = "SELECT * FROM [graduating_class]";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
			command.CommandText = query;

			IDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				GraduatingClass graduatingClass = GraduatingClassHelper.GenerateGraduatingClassFromDataBase(reader);
				result.Add(graduatingClass);
			}
			_dbConnection.Close();
			return result;
		}

		public GraduatingClass? GetGraduatingClass(int id)
		{
			GraduatingClass? result = null;

			string query = $"SELECT * FROM [graduating_class] WHERE id_graduating_class = {id}";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
			command.CommandText = query;

			IDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				result = GraduatingClassHelper.GenerateGraduatingClassFromDataBase(reader);
			}
			_dbConnection.Close();
			return result;
		}
	}
}
