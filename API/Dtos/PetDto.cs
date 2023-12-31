using Core.Enums;

namespace FloofyWoof.Dtos;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PetTypeEnum PetType { get; set; }
}