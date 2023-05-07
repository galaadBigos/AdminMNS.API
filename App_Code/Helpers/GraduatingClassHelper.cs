using AdminMNS.API.Models;
using System.Data;

namespace AdminMNS.API.App_Code.Helpers
{
	public class GraduatingClassHelper
	{
		internal static GraduatingClass GenerateGraduatingClassFromDataBase(IDataReader reader)
		{
			return new GraduatingClass()
			{
				Id = reader.GetInt32(0),
				Name = reader.GetString(1),
				StartDate = reader.GetDateTime(2),
				EndDate = reader.GetDateTime(3),
			};
		}
	}
}
