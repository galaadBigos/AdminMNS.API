using AdminMNS.API.Models;
using System.Data;
using System.Reflection;

namespace AdminMNS.API.App_Code.Helpers
{
	public static class PostHelper
	{
		public static string GenerateSecurePostQuery(DatabaseTable table, string nameTable)
		{
			string result = $"INSERT INTO {nameTable} VALUES (";
			PropertyInfo[] properties = table.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
			{
				if (property.Name != "Id")
					result += $"@{property.Name}, ";
			}
			result = result[0..(result.Length - 2)];
			result += ");";

			return result.ToString();
		}
	}
}
