namespace Core.Entities;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Pet> Pets { get; set; }
}