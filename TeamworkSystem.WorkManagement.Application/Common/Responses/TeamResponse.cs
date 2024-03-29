﻿namespace TeamworkSystem.WorkManagement.Application.Common.Responses;

public class TeamResponse
{
    public Guid Id { get; set; }
    public Guid? LeaderId { get; set; }
    public string Name { get; set; } = default!;
    public string? Specialization { get; set; }
    public string? About { get; set; }
    public string? Avatar { get; set; }
    public UserResponse? Leader { get; set; }
}
