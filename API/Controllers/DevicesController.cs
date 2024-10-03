using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DataContext _context;

        public DevicesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Device>> GetDevices()
        {
            var devices = _context.Devices.ToList();

            return devices;
        }

    }
}
