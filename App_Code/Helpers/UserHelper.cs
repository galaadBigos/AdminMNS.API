using AdminMNS.API.Models;
using System.Data;

namespace AdminMNS.API.App_Code.Helpers
{
	public class UserHelper
	{
		public static User GenerateUser(IDataReader reader)
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
	}
}
