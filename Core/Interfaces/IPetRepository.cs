using Core.Entities;

namespace Core.Interfaces;

public interface IPetRepository
{
    Task<Pet> GetPetByIdAsync(int id);
    Task<IReadOnlyList<Pet>> GetPetsAsync();
    Task<int> AddPetAsync(string name);
    Task<Pet> UpdatePetAsync(Pet pet);
}