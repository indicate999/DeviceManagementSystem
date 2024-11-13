namespace API.BusinessLogic.Exceptions;

public class DeviceNotFoundException : Exception
{
	public DeviceNotFoundException() : base("Device not found.")
	{
	}
}