using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminMNS.API.Repository
{
    public class UserRepository : IUserRepository
	{
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> result = new List<User>();

            string query = "SELECT * FROM [User]";

            _dbConnection.Open();
            IDbCommand command = _dbConnection.CreateCommand();
            command.CommandText = query;

            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User user = UserHelper.GenerateUserFromDataBase(reader);
                result.Add(user);
            }
            _dbConnection.Close();
            return result;
        }

        public User? GetUserById(int id)
        {
            User? result = null;

            string query = $"SELECT * FROM [User] WHERE Id_user = {id}";

            _dbConnection.Open();
            IDbCommand command = _dbConnection.CreateCommand();
            command.CommandText = query;

            IDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result = UserHelper.GenerateUserFromDataBase(reader);
            }
            _dbConnection.Close();
            return result;
        }

		public IEnumerable<User> GetUsersByGraduatingClass(int id)
		{
			List<User> result = new List<User>();

			string query = $"SELECT * FROM [User] WHERE id_graduating_class = {id}";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
			command.CommandText = query;

			IDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				User user = UserHelper.GenerateUserFromDataBase(reader);
				result.Add(user);
			}
			_dbConnection.Close();
			return result;
		}

		public void PostUser(User user)
		{
            string query = PostHelper.GenerateSecurePostQuery(user);

            _dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
 
			command.CommandText = query;

            PostHelper.AddParametersToDbCommand(command, user);

			command.ExecuteNonQuery();

			_dbConnection.Close();
		}
	}
}
