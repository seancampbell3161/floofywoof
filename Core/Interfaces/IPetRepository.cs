using Core.Entities;

namespace Core.Interfaces;

public interface IPetRepository
{
    Task<Pet> GetPetByIdAsync(int id);
    Task<IReadOnlyList<Pet>> GetPetsAsync();
    Task<int> AddPetAsync(string name, int petType);
    Task<Pet> UpdatePetAsync(Pet pet);
}