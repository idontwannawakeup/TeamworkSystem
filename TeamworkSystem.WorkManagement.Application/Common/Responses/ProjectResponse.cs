﻿namespace TeamworkSystem.WorkManagement.Application.Common.Responses;

public class ProjectResponse
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }

    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }

    public TeamResponse Team { get; set; } = default!;
}
