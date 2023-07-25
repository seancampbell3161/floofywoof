using AutoMapper;
using Core.Entities;
using FloofyWoof.Dtos;

namespace FloofyWoof.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pet, PetDto>().ReverseMap();
    }
}