using API.Data;
using API.DTOs;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DeviceRepository _deviceRepository;
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(DeviceRepository deviceRepository, ILogger<DevicesController> logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Device>> GetDevices()
        {
            _logger.LogDebug("kkkk");
            _logger.LogDebug(_deviceRepository.ToString());
            return _deviceRepository.GetDevices();
        }

        [HttpPost]
        public IActionResult AddDevice([FromBody] DeviceDto deviceDto)
        {
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

    }
}
