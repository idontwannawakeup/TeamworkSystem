﻿namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses;

public class RatingResponse
{
    public int Id { get; set; }

    public string FromId { get; set; } = default!;

    public string ToId { get; set; } = default!;

    public int Social { get; set; }

    public int Skills { get; set; }

    public int Responsibility { get; set; }

    public int Punctuality { get; set; }

    public double Average { get; set; }

    public string? Comment { get; set; }

    public UserResponse From { get; set; } = default!;

    public UserResponse To { get; set; } = default!;
}
