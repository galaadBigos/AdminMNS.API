using AdminMNS.API.Domain.DTO;
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

		public static GraduatingClass GenerateGraduationgClassFromItemDTO(GraduatingClassItemDTO graduatingClassItemDTO)
		{
			return new GraduatingClass()
			{
				Id = graduatingClassItemDTO.Id,
				Name = graduatingClassItemDTO.Name,
				StartDate = graduatingClassItemDTO.StartDate,
				EndDate = graduatingClassItemDTO.EndDate,
			};
		}
	}
}
