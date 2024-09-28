using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Device>> GetDevices()
        {

            List<Device> devices = new List<Device>
            {
                new Device { Brand = "Apple", Manufacturer = "Apple Inc.", ModelName = "MacBook Pro", OperatingSystem = "macOS" },
                new Device { Brand = "Dell", Manufacturer = "Dell Technologies", ModelName = "XPS 13", OperatingSystem = "Windows 11" },
                new Device { Brand = "HP", Manufacturer = "Hewlett-Packard", ModelName = "Spectre x360", OperatingSystem = "Windows 11" },
                new Device { Brand = "Lenovo", Manufacturer = "Lenovo Group", ModelName = "ThinkPad X1 Carbon", OperatingSystem = "Windows 11" },
                new Device { Brand = "Microsoft", Manufacturer = "Microsoft", ModelName = "Surface Laptop 4", OperatingSystem = "Windows 11" },
                new Device { Brand = "Asus", Manufacturer = "ASUSTeK Computer Inc.", ModelName = "ZenBook 14", OperatingSystem = "Windows 11" },
                new Device { Brand = "Acer", Manufacturer = "Acer Inc.", ModelName = "Swift 3", OperatingSystem = "Windows 11" },
                new Device { Brand = "Apple", Manufacturer = "Apple Inc.", ModelName = "iMac 24\"", OperatingSystem = "macOS" },
                new Device { Brand = "Sony", Manufacturer = "Sony Corporation", ModelName = "PlayStation 5", OperatingSystem = "Custom OS" },
                new Device { Brand = "Microsoft", Manufacturer = "Microsoft", ModelName = "Xbox Series X", OperatingSystem = "Custom OS" },
                new Device { Brand = "Nintendo", Manufacturer = "Nintendo", ModelName = "Switch", OperatingSystem = "Custom OS" },
                new Device { Brand = "Alienware", Manufacturer = "Dell Technologies", ModelName = "Alienware m15", OperatingSystem = "Windows 11" },
                new Device { Brand = "Razer", Manufacturer = "Razer Inc.", ModelName = "Razer Blade 15", OperatingSystem = "Windows 11" },
                new Device { Brand = "MSI", Manufacturer = "MSI", ModelName = "MSI GS66", OperatingSystem = "Windows 11" },
                new Device { Brand = "Gigabyte", Manufacturer = "Gigabyte Technology", ModelName = "Aero 15", OperatingSystem = "Windows 11" },
                new Device { Brand = "Samsung", Manufacturer = "Samsung Electronics", ModelName = "Galaxy Book Pro", OperatingSystem = "Windows 11" },
                new Device { Brand = "Apple", Manufacturer = "Apple Inc.", ModelName = "Mac Mini", OperatingSystem = "macOS" },
                new Device { Brand = "Valve", Manufacturer = "Valve Corporation", ModelName = "Steam Deck", OperatingSystem = "SteamOS" },
                new Device { Brand = "LG", Manufacturer = "LG Electronics", ModelName = "Gram 17", OperatingSystem = "Windows 11" },
                new Device { Brand = "HP", Manufacturer = "Hewlett-Packard", ModelName = "Omen 15", OperatingSystem = "Windows 11" }
            };

            return devices;
        }

    }
}
