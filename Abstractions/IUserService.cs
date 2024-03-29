﻿using AdminMNS.API.Domain.DTO;

namespace AdminMNS.API.Abstractions
{
	public interface IUserService
	{
		public IEnumerable<UserItemDTO>? GetUserItemDTOs();
		public UserItemDTO? GetUserItemDTO(int id);
		public List<UserItemDTO>? GetUserItemDTOsByGraduatingClass(int id);
		public void PostNewUser(UserItemDTO userItemDTO);
		public void DeleteUser(int id);
	}
}
