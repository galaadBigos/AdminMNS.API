using AdminMNS.API.Models;

namespace AdminMNS.API.Abstractions
{
	public interface IUserRepository
	{
		public IEnumerable<User> GetUsers();
		public User? GetUserById(int id);
		IEnumerable<User>? GetUsersByGraduatingClass(int id);
		void PostUser(User user);
		void DeleteUser(int id);
	}
}
