﻿namespace TeamworkSystem.Core.BusinessLogic.DTO.Requests;

public class TeamMemberRequest
{
    public Guid UserId { get; set; } = default!;
    public Guid TeamId { get; set; }
}