namespace AdminMNS.API.App_Code.Exceptions
{
	public static class ErrorMessageHelper
	{
		public static string DisplayErrorMessage(string errorMessage)
		{
			return $"Error Message: {errorMessage}";
		}

		public static string DisplayErrorMessage(string errorMessage, int errorNumber)
		{
			return $"Error Number:{errorNumber}\nError Message: {errorMessage}";
		}
	}
}
