using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}