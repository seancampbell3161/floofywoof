using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser<int>
{
    public DateTime Created { get; set; } = DateTime.Now;
    
    public ICollection<AppUserRole> UserRoles { get; set; }
}