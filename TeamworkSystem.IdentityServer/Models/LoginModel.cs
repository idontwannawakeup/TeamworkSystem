using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Identity.API.Models;

public class LoginModel
{
    [Required]
    public string Username { get; set; } = default!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    public string? ReturnUrl { get; set; } = default!;
}
