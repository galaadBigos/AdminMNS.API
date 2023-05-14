using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Exceptions;
using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminMNS.API.Repository
{
	public class GraduatingClassRepository : AbstractRepository, IGraduatingClassRepository
	{
		public GraduatingClassRepository(IDbConnection dbConnection) : base(dbConnection)
		{
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

		public void PostGraduatingClass(GraduatingClass graduatingClass)
		{
			string query = PostHelper.GenerateSecurePostQuery(graduatingClass, "graduating_class");

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();

			command.CommandText = query;

			CRUDHelper.AddParametersToDbCommand(command, graduatingClass);

			if (command.ExecuteNonQuery() <= 0)
			{
				throw new InsertSqlException("The insert query did not work");
			}
			
			_dbConnection.Close();
		}

		public void UpdateGraduatingClass(GraduatingClass graduatingClass)
		{
			string query = UpdateHelper.GenerateSecureUpdateQueryGraduatingClass(graduatingClass);

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();

			command.CommandText = query;

			CRUDHelper.AddParametersToDbCommand(command, graduatingClass);

			if (command.ExecuteNonQuery() <= 0)
			{
				throw new InsertSqlException("The update query did not work");
			}
			_dbConnection.Close();
		}

		public void DeleteGraduatingClass(int id)
		{
			string query = $"DELETE FROM [graduating_class] WHERE id_graduating_class = {id}";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();

			command.CommandText = query;

			if (command.ExecuteNonQuery() <= 0)
			{
				throw new DeleteSqlException("The delete query did not work");
			}

			_dbConnection.Close();
		}
	}
}
