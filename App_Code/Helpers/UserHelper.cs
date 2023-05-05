using AdminMNS.API.Domain.DTO;
using AdminMNS.API.Models;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace AdminMNS.API.App_Code.Helpers
{
	public class UserHelper
	{
		public static User GenerateUserFromDataBase(IDataReader reader)
		{
			return new User()
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
		}

		public static User GenerateUserFromCreatePost(UserItemDTO userItemDTO)
		{
			return new User()
			{
				Id = userItemDTO.Id,
				Firstname = userItemDTO.Firstname,
				Lastname = userItemDTO.Lastname,
				Birthday = userItemDTO.Birthday,
				Password = GetRandomPassword(12),
				MailAddress = userItemDTO.MailAddress,
				WayNumber = userItemDTO.WayNumber,
				WayType = userItemDTO.WayType,
				WayName = userItemDTO.WayName,
				City = userItemDTO.City,
				PostalCode = userItemDTO.PostalCode,
				IsValidRegistration = userItemDTO.IsValidRegistration,
				IdUserStatus = userItemDTO.IdUserStatus,
				IdGraduatingClass = userItemDTO.IdGraduatingClass,
			};
		}

		private static string GetRandomPassword(int length)
		{
			StringBuilder result = new StringBuilder();

			const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
			Random random = new Random();
			while (0 < length--)
			{
				result.Append(valid[random.Next(valid.Length)]);
			}
			return result.ToString();
		}
	}
}
