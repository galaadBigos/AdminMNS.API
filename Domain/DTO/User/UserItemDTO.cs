using AdminMNS.API.Models;

namespace AdminMNS.API.Domain.DTO
{
	public class UserItemDTO
	{
		public int Id { get; set; }
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public DateTime Birthday { get; set; }
		public string? MailAddress { get; set; }
		public string? WayNumber { get; set; }
		public string? WayType { get; set; }
		public string? WayName { get; set; }
		public string? City { get; set; }
		public string? PostalCode { get; set; }
		public bool IsValidRegistration { get; set; }
		public int IdUserStatus { get; set; }
		public int IdGraduatingClass { get; set; }

		public UserItemDTO(User user)
		{
			if (user != null)
			{
				Id = user.Id;
				Firstname = user.Firstname;
				Lastname = user.Lastname;
				Birthday = user.Birthday;
				MailAddress = user.MailAddress;
				WayNumber = user.WayNumber;
				WayType = user.WayType;
				WayName = user.WayName;
				City = user.City;
				PostalCode = user.PostalCode;
				IsValidRegistration = user.IsValidRegistration;
				IdUserStatus = user.IdUserStatus;
				IdGraduatingClass = user.IdGraduatingClass;
			}
        }
    }
}
