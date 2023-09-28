using AdminMNS.API.Models;
using System.Reflection;

namespace AdminMNS.API.App_Code.Helpers
{
	public class UpdateHelper
	{
		public static string GenerateSecureUpdateQueryGraduatingClass(GraduatingClass graduatingClass)
		{
			string result = $"UPDATE [graduating_class] SET " +
				$"name_graduating_class = @Name, " +
				$"start_date_graduating_class = @StartDate, " +
				$"end_date_graduating_class = @EndDate " +
				$"WHERE id_graduating_class = {graduatingClass.Id};";

			return result.ToString();
		}
	}
}
