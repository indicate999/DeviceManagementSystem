using API.BusinessLogic.DTOs;
using API.Data.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		CreateMap<DeviceDto, Device>();
	}
}