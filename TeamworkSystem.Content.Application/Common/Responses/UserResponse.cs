﻿namespace TeamworkSystem.Content.Application.Common.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
    public string? Avatar { get; set; }
}
