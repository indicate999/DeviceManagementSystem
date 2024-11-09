using API.Data.Entities;

namespace API.Data.Repositories.Interfaces;
public interface IDeviceRepository
{
	List<Device> GetDevices();
	void AddDevice(Device device);
	void EditDevice(Device device);
	Device GetDeviceById(int id);
	void DeleteDevice(Device device);
	bool Complete();
}