using API.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;
using API.BusinessLogic.Services.Interfaces;
using API.BusinessLogic.Exceptions;
using API.Data.Entities;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DevicesController : ControllerBase
	{
		private readonly IDeviceService _deviceService;
		private readonly ILogger<DevicesController> _logger;

		public DevicesController(IDeviceService deviceService, ILogger<DevicesController> logger)
		{
			_deviceService = deviceService;
			_logger = logger;
		}

		[HttpGet]
		public ActionResult<List<Device>> GetDevices()
		{
			_logger.LogDebug("get");

			return _deviceService.GetDevices();
		}

		[HttpPost]
		public IActionResult AddDevice([FromBody] DeviceDto deviceDto)
		{
			_logger.LogDebug("add");

			if (deviceDto == null)
			{
				return BadRequest();
			}

			try
			{
				_deviceService.AddDevice(deviceDto);
			}
			catch (DbChangesNotSavedException exception)
			{
				return StatusCode(500, exception.Message);
			}

			return CreatedAtAction(nameof(AddDevice), deviceDto);
		}

		[HttpPut]
		public ActionResult EditDevice([FromBody] DeviceDto updatedDeviceDto)
		{
			_logger.LogDebug("edit");

			if (updatedDeviceDto == null)
			{
				return BadRequest();
			}

			try
			{
				_deviceService.UpdateDevice(updatedDeviceDto);
			}
			catch (DeviceNotFoundException exception)
			{
				return BadRequest(exception.Message);
			}
			catch (DbChangesNotSavedException exception)
			{
				return StatusCode(500, exception.Message);
			}

			return NoContent();
		}

		[HttpDelete("{deviceId}")]
		public ActionResult DeleteDevice(int deviceId)
		{
			_logger.LogDebug("delete");

			try
			{
				_deviceService.DeleteDevice(deviceId);
			}
			catch (DeviceNotFoundException exception)
			{
				return BadRequest(exception.Message);
			}
			catch (DbChangesNotSavedException exception)
			{
				return StatusCode(500, exception.Message);
			}

			return NoContent();
		}
	}
}
