using AdminMNS.API.Models;
using System.Data;
using System.Reflection;

namespace AdminMNS.API.App_Code.Helpers
{
	public static class CRUDHelper
	{
		public static void AddParametersToDbCommand(IDbCommand command, DatabaseTable table)
		{
			PropertyInfo[] props = table.GetType().GetProperties();

			foreach (PropertyInfo prop in props)
			{
				if (prop.Name != "Id")
				{
					IDbDataParameter parameter = command.CreateParameter();
					parameter.ParameterName = $"@{prop.Name}";
					//parameter.Size = 50;
					parameter.Value = prop.GetValue(table);
					command.Parameters.Add(parameter);
				}
			}
		}
	}
}
