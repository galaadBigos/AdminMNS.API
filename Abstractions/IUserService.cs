using AdminMNS.API.Domain.DTO;

namespace AdminMNS.API.Abstractions
{
	public interface IUserService
	{
		public IEnumerable<UserItemDTO>? GetUserItemDTOs();
		public UserItemDTO? GetUserItemDTO(int id);

	}
}
