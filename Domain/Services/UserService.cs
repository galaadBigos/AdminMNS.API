using AdminMNS.API.Abstractions;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminMNS.API.Domain.Services
{
	public class UserService : IUserService
	{
		private readonly IDbConnection _dbConnection;

		public UserService(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public IEnumerable<UserItemDTO> GetUserItemDTOs()
		{
			List<UserItemDTO> result = new List<UserItemDTO>();

			string query = "SELECT * FROM [User]";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
			command.CommandText = query;

			IDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				User user = new User()
				{
					Id = reader.GetInt32(0),
					Firstname = reader.GetString(1),
					Lastname = reader.GetString(2),
					Birthday = reader.GetDateTime(3),
					Password = reader.GetString(4),
					MailAddress = reader.GetString(5),
					WayNumber = reader.GetString(6),
					WayType = reader.GetString(7),
					WayName = reader.GetString(8),
					City = reader.GetString(9),
					PostalCode = reader.GetString(10),
					IsValidRegistration = reader.GetBoolean(11),
					IdUserStatus = reader.GetInt32(12),
					IdGraduatingClass = reader.GetInt32(13),
				};
				result.Add(new UserItemDTO(user));
			}
			_dbConnection.Close();
			return result;
		}

		public UserItemDTO GetUserItemDTO(int id)
		{
			UserItemDTO result = new UserItemDTO(new User());
			string query = $"SELECT * FROM [User] WHERE Id_user = {id}";

			_dbConnection.Open();
			IDbCommand command = _dbConnection.CreateCommand();
			command.CommandText = query;

			IDataReader reader = command.ExecuteReader();

			while (reader.Read())
			{
				User user = new User()
				{
					Id = reader.GetInt32(0),
					Firstname = reader.GetString(1),
					Lastname = reader.GetString(2),
					Birthday = reader.GetDateTime(3),
					Password = reader.GetString(4),
					MailAddress = reader.GetString(5),
					WayNumber = reader.GetString(6),
					WayType = reader.GetString(7),
					WayName = reader.GetString(8),
					City = reader.GetString(9),
					PostalCode = reader.GetString(10),
					IsValidRegistration = reader.GetBoolean(11),
					IdUserStatus = reader.GetInt32(12),
					IdGraduatingClass = reader.GetInt32(13),
				};
				result = new UserItemDTO(user);
			}
			_dbConnection.Close();
			return result;
		}
	}
}
