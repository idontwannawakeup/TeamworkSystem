namespace TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;

public class UserRequest
{
    public Guid Id { get; set; } = default!;

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
}
