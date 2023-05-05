using AdminMNS.API.Abstractions;
using AdminMNS.API.App_Code.Helpers;
using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Models;
using AdminMNS.API.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdminMNS.API.Domain.Services
{
    public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
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

		public List<UserItemDTO> GetUserItemDTOsByGraduatingClass(int id)
		{
			IEnumerable<User>? users = _userRepository.GetUsersByGraduatingClass(id);

			return users.Select(user => new UserItemDTO(user)).ToList();
		}

		public void PostNewUser(UserItemDTO userItemDTO)
		{
			User user = UserHelper.GenerateUserFromCreatePost(userItemDTO);

			_userRepository.PostUser(user);
		}
	}
}
