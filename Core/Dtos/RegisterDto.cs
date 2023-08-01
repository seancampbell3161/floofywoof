using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [StringLength(16, MinimumLength = 6)]
    public string Password { get; set; }
}