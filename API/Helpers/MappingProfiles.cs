using AutoMapper;
using Core.Dtos;
using Core.Entities;
using FloofyWoof.Dtos;

namespace FloofyWoof.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pet, PetDto>().ReverseMap();
        CreateMap<RegisterDto, AppUser>();
    }
}