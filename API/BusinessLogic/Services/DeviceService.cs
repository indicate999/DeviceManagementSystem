using API.BusinessLogic.DTOs;
using API.BusinessLogic.Exceptions;
using API.BusinessLogic.Services.Interfaces;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using AutoMapper;

namespace API.BusinessLogic.Services;

public class DeviceService : IDeviceService
{
	private readonly IDeviceRepository _deviceRepository;
	private readonly IMapper _mapper;

	public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
	{
		_deviceRepository = deviceRepository;
		_mapper = mapper;
	}
	public List<Device> GetDevices()
	{
		return _deviceRepository.GetDevices();
	}

	public void AddDevice(DeviceDto deviceDto)
	{
		var device = _mapper.Map<Device>(deviceDto);

		_deviceRepository.AddDevice(device);

		if (!_deviceRepository.Complete())
		{
			throw new DbChangesNotSavedException("Device wasn't added to the database.");
		}

	}

	public void UpdateDevice(DeviceDto updatedDeviceDto)
	{
		var existingDevice = _deviceRepository.GetDeviceById(updatedDeviceDto.Id);

		if (existingDevice == null)
		{
			throw new DeviceNotFoundException();
		}

		_mapper.Map(updatedDeviceDto, existingDevice);

		if (!_deviceRepository.Complete())
		{
			throw new DbChangesNotSavedException("The changes weren't saved in the database."); ;
		}
	}

	public void DeleteDevice(int deviceId)
	{
		var deletingDevice = _deviceRepository.GetDeviceById(deviceId);

		if (deletingDevice == null)
		{
			throw new DeviceNotFoundException();
		}

		_deviceRepository.DeleteDevice(deletingDevice);

		if (!_deviceRepository.Complete())
		{
			throw new DbChangesNotSavedException("Device wasn't removed from the database.");
		}
	}
}