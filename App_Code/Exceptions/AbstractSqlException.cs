namespace AdminMNS.API.App_Code.Exceptions
{
	public abstract class AbstractSqlException : Exception
	{
        public AbstractSqlException(string message) : base(message)
        {
            
        }
    }
}
