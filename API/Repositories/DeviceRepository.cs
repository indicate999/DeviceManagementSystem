using System;
using API.Data;
using API.Entities;

namespace API.Repositories;

public class DeviceRepository
{
    private readonly DataContext _context;

    public DeviceRepository(DataContext context)
    {
        _context = context;
    }

    public List<Device> GetDevices() {
        return _context.Devices.ToList();
    }

    public void AddDevice(Device device) {
        _context.Devices.Add(device);
    }

    public bool Complete()
    {
        return _context.SaveChanges() > 0;
    }
}
