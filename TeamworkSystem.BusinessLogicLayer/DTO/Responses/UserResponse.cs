﻿namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses;

public class UserResponse
{
    public string Id { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string FullName { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string? Profession { get; set; }

    public string? Specialization { get; set; }

    public string? Avatar { get; set; }
}
