using API.BusinessLogic.DTOs;
using API.BusinessLogic.Exceptions;
using API.BusinessLogic.Services.Interfaces;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;

namespace API.BusinessLogic.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository) 
        {
            _deviceRepository = deviceRepository;
        }
        public List<Device> GetDevices()
        {
            return _deviceRepository.GetDevices();
        }

        public void AddDevice(DeviceDto deviceDto)
        {
            // TODO: Use Automapping
            var device = new Device
            {
                Brand = deviceDto.Brand,
                Manufacturer = deviceDto.Manufacturer,
                ModelName = deviceDto.ModelName,
                OperatingSystem = deviceDto.OperatingSystem
            };

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

            // TODO: Decide if it is needed
            /*if (existingDevice.Brand == updatedDeviceDto.Brand
                && existingDevice.Manufacturer == updatedDeviceDto.Manufacturer
                && existingDevice.ModelName == updatedDeviceDto.ModelName
                && existingDevice.OperatingSystem == updatedDeviceDto.OperatingSystem)
            {
                throw new NoChangesException();;
            }*/

            // TODO: Use Automapping
            existingDevice.Brand = updatedDeviceDto.Brand;
            existingDevice.Manufacturer = updatedDeviceDto.Manufacturer;
            existingDevice.ModelName = updatedDeviceDto.ModelName;
            existingDevice.OperatingSystem = updatedDeviceDto.OperatingSystem;

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
}
