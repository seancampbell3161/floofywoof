using Core.Entities;
using Core.Interfaces;
using FloofyWoof.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FloofyWoof.Controllers;

public class PetController : BaseApiController
{
    private readonly IPetRepository _petRepository;

    public PetController(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPets()
    {
        var pets = await _petRepository.GetPetsAsync();

        return Ok(pets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        return Ok(pet);
    }

    [HttpPost]
    public async Task<IActionResult> AddPet(string name)
    {
        var addPet = await _petRepository.AddPetAsync(name);

        return Ok(addPet);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePet(Pet pet)
    {
        var updatePet = await _petRepository.UpdatePetAsync(pet);

        return Ok(updatePet);
    }
}