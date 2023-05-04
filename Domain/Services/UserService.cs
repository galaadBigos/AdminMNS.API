using AdminMNS.API.Abstractions;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Models;
using AdminMNS.API.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminMNS.API.Domain.Services
{
    public class UserService : IUserService
	{
		private readonly IDbConnection _dbConnection;
		private readonly UserRepository _userRepository;

		public UserService(IDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
			_userRepository = new UserRepository(_dbConnection);
		}

		public IEnumerable<UserItemDTO> GetUserItemDTOs()
		{
			IEnumerable<User> users = _userRepository.GetUsers();

			return users.Select(user => new UserItemDTO(user)).ToList();
		}

		public UserItemDTO? GetUserItemDTO(int id)
		{
			User? user = _userRepository.GetUserById(id);
			if (user != null)
				return new UserItemDTO(user);
			return null;
		}
	}
}
