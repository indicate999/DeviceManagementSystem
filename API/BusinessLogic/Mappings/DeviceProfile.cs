using API.BusinessLogic.DTOs;
using API.Data.Entities;
using AutoMapper;

namespace API.BusinessLogic.Mappings;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<DeviceDto, Device>();
    }
}