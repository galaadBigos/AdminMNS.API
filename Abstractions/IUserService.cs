using AdminMNS.API.Domain.DTO;

namespace AdminMNS.API.Abstractions
{
	public interface IUserService
	{
		public UserItemDTO GetUserItemDTO(int id);
		public IEnumerable<UserItemDTO> GetUserItemDTOs();

	}
}
