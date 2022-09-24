namespace TeamworkSystem.Identity.People.BusinessLogic.DTO.Responses;

public class JwtResponse
{
    // TODO remove this property. It's temporary
    public Guid UserId { get; set; } = default!;

    public string Token { get; set; } = default!;
}
