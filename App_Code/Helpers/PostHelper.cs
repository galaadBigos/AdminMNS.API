using AdminMNS.API.Models;
using System.Data;
using System.Reflection;

namespace AdminMNS.API.App_Code.Helpers
{
	public static class PostHelper
	{
		public static string GenerateSecurePostQuery(AbstractTable table)
		{
			string result = $"INSERT INTO [User] VALUES (";
			PropertyInfo[] props = table.GetType().GetProperties();

			foreach (PropertyInfo prop in props)
			{
				if (prop.Name != "Id")
					result += $"@{prop.Name}, ";
			}
			result = result[0..(result.Length - 2)];
			result += ");";

			return result.ToString();
		}

		public static void AddParametersToDbCommand(IDbCommand command, AbstractTable table)
		{
			PropertyInfo[] props = table.GetType().GetProperties();

			foreach (PropertyInfo prop in props)
			{
				if (prop.Name != "Id")
				{
					IDbDataParameter parameter = command.CreateParameter();
					parameter.ParameterName = $"@{prop.Name}";
					parameter.Size = 50;
					parameter.Value = prop.GetValue(table);
					command.Parameters.Add(parameter);
				}
			}
		}
	}
}
