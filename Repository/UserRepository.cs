using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Models;
using System.Data;

namespace AdminMNS.API.Repository
{
    public class UserRepository
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
                User user = UserHelper.GenerateUser(reader);
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
                result = UserHelper.GenerateUser(reader);
            }
            _dbConnection.Close();
            return result;
        }
    }
}
