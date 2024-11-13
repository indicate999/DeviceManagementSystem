using API.Data.Repositories;
using API.Data.Repositories.Interfaces;

namespace API.Data.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IDeviceRepository, DeviceRepository>();

		return services;
	}

}