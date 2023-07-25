using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _db;

    public PetRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Pet> GetPetByIdAsync(int id)
    {
        var pet = await _db.Pets.FindAsync(id);

        return pet ?? new Pet();
    }

    public async Task<IReadOnlyList<Pet>> GetPetsAsync()
    {
        var pets = await _db.Pets.ToListAsync();

        return pets;
    }

    public async Task<int> AddPetAsync(string name, int petType)
    {
        await _db.Pets.AddAsync(new Pet() { Id = 0, Name = name, PetType = petType});

        return (await _db.SaveChangesAsync());
    }

    public async Task<Pet> UpdatePetAsync(Pet pet)
    {
        var entity = await _db.Pets.FindAsync(pet.Id);

        if (entity == null) return new Pet();

        entity = pet;

        await _db.SaveChangesAsync();

        return entity;
    }
}