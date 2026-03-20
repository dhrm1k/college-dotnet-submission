using System.ComponentModel.DataAnnotations;

namespace BackendDevWithDotNet.Models;

public class UserCreateRequest
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Range(18, 120)]
    public int Age { get; set; }
}
