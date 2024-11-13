using API.BusinessLogic.Services;
using API.BusinessLogic.Services.Interfaces;

namespace API.BusinessLogic.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddScoped<IDeviceService, DeviceService>();

		return services;
	}
}