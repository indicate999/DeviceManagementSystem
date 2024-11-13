namespace API.BusinessLogic.Exceptions;

public class DbChangesNotSavedException : Exception
{
	public DbChangesNotSavedException(string message) : base(message)
	{
	}
}