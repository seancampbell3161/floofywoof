using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using FloofyWoof.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FloofyWoof.Controllers;

public class PetController : BaseApiController
{
    private readonly IPetRepository _petRepository;
    private readonly IMapper _mapper;

    public PetController(IPetRepository petRepository, IMapper mapper)
    {
        _petRepository = petRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<PetDto>>> GetPets()
    {
        var pets = await _petRepository.GetPetsAsync();

        return Ok(_mapper.Map<List<PetDto>>(pets));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PetDto>> GetPetById(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        return Ok(_mapper.Map<PetDto>(pet));
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddPet(string name, int petType)
    {
        var addPet = await _petRepository.AddPetAsync(name, petType);

        return Ok(addPet);
    }

    [HttpPut]
    public async Task<ActionResult<PetDto>> UpdatePet(Pet pet)
    {
        var updatePet = await _petRepository.UpdatePetAsync(pet);

        return Ok(_mapper.Map<PetDto>(updatePet));
    }
}