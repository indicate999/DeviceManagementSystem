using System.Diagnostics;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<DevicesController> _logger;

        public DevicesController(DataContext context, ILogger<DevicesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Device>> GetDevices()
        {
            var devices = _context.Devices.ToList();

            return devices;
        }

        [HttpPost]
        public IActionResult AddDevice(DeviceDto deviceDto)
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

            _context.Devices.Add(device);

            int result = _context.SaveChanges();

            if (result > 0)
            {
                return CreatedAtAction(nameof(AddDevice), device);
            }

            return BadRequest("Problem adding device");
        }

    }
}
