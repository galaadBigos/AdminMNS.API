using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Models;
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
            string query = $"INSERT INTO [User] VALUES " +
                $"@Firstname," +
                $"@Lastname," +
                $"@Birthday," +
                $"@Password," +
                $"@MailAddress," +
                $"@WayNumber," +
                $"@WayType," +
                $"@WayName," +
                $"@City," +
                $"@PostalCode," +
                $"@IsValidRegistration," +
                $"@IdUserStatus," +
                $"@IdGraduatingClass" +
                $");";



			//$"(" +
			//$"'{user.Firstname}'," +
			//$"'{user.Lastname}'," +
			//$"'{user.Birthday}'," +
			//$"'{user.Password}'," +
			//$"'{user.MailAddress}'," +
			//$"'{user.WayNumber}'," +
			//$"'{user.WayType}'," +
			//$"'{user.WayName}'," +
			//$"'{user.City}'," +
			//$"'{user.PostalCode}'," +
			//$"'{user.IsValidRegistration}'," +
			//$"{user.IdUserStatus}," +
			//$"{user.IdGraduatingClass}" +
			//$")";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
			command.CommandText = query;

            IDbDataParameter dbDataParameter = command.CreateParameter();
            dbDataParameter.

            command.ExecuteNonQuery();

			_dbConnection.Close();
		}
	}
}
