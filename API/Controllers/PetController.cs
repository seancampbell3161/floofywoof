using FloofyWoof.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FloofyWoof.Controllers;

public class PetController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetPets()
    {
        var pets = new List<PetDto>();

        var pet1 = new PetDto()
        {
            Id = 1,
            Name = "Spring"
        };

        var pet2 = new PetDto()
        {
            Id = 2,
            Name = "Tucky"
        };

        var pet3 = new PetDto()
        {
            Id = 3,
            Name = "Bisky"
        };
        
        pets.Add(pet1);
        pets.Add(pet2);
        pets.Add(pet3);

        return Ok(pets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(int id)
    {
        var pet = new PetDto()
        {
            Id = id,
            Name = "Spring"
        };

        return Ok(pet);
    }
}