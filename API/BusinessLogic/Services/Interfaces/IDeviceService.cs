using API.BusinessLogic.DTOs;
using API.Data.Entities;

namespace API.BusinessLogic.Services.Interfaces;

public interface IDeviceService
{
	List<Device> GetDevices();

	void AddDevice(DeviceDto deviceDto);

	void UpdateDevice(DeviceDto updatedDeviceDto);

	void DeleteDevice(int deviceId);
}