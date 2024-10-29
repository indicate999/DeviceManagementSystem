using API.Data;
using API.Data.Entities;
using API.Data.Repositories;
using API.BisnessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DevicesController : ControllerBase
	{
		private readonly IDeviceRepository _deviceRepository;
		private readonly ILogger<DevicesController> _logger;

		public DevicesController(IDeviceRepository deviceRepository, ILogger<DevicesController> logger)
		{
			_deviceRepository = deviceRepository;
			_logger = logger;
		}

		[HttpGet]
		public ActionResult<List<Device>> GetDevices()
		{
			_logger.LogDebug("get");

			return _deviceRepository.GetDevices();
		}

		[HttpPost]
		public IActionResult AddDevice([FromBody] DeviceDto deviceDto)
		{
			_logger.LogDebug("add");
			
			if (deviceDto == null)
			{
				return BadRequest();
			}

			var device = new Device
			{
				Brand = deviceDto.Brand,
				Manufacturer = deviceDto.Manufacturer,
				ModelName = deviceDto.ModelName,
				OperatingSystem = deviceDto.OperatingSystem
			};

			_deviceRepository.AddDevice(device);

			if (_deviceRepository.Complete())
			{
				return CreatedAtAction(nameof(AddDevice), device);
			}

			return BadRequest("Problem adding device");
		}
		
		[HttpPut("{deviceId}")]
		public ActionResult EditDevice([FromBody] DeviceDto updatedDeviceDto, int deviceId) 
		{
			_logger.LogDebug("edit");
			
			var existingDevice = _deviceRepository.GetDeviceById(deviceId);
			
			if (existingDevice == null)
			{
				return NotFound("Device not found.");
			}
			
			if (existingDevice.Brand == updatedDeviceDto.Brand 
				&& existingDevice.Manufacturer == updatedDeviceDto.Manufacturer
				&& existingDevice.ModelName == updatedDeviceDto.ModelName 
				&& existingDevice.OperatingSystem == updatedDeviceDto.OperatingSystem)
			{
				return BadRequest("You can not edit device without changes");
			}
			
			existingDevice.Brand = updatedDeviceDto.Brand;
			existingDevice.Manufacturer = updatedDeviceDto.Manufacturer;
			existingDevice.ModelName = updatedDeviceDto.ModelName;
			existingDevice.OperatingSystem = updatedDeviceDto.OperatingSystem;
			
			if (!_deviceRepository.Complete())
			{
				return StatusCode(500, "An error occurred while updating the device.");
			}
			
			return NoContent();
		}

	}
}
