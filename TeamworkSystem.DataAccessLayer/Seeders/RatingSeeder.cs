﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Seeders;

namespace TeamworkSystem.DataAccessLayer.Seeders;

public class RatingSeeder : IRatingSeeder
{
    private static readonly List<Rating> Ratings = new()
    {
        new Rating
        {
            Id = 1,
            FromId = "3b333929-f974-444e-a8d3-68f50a0459c0",
            ToId = "61dfb9e3-1c27-424a-9963-9586ca110220",
            Social = 5,
            Skills = 5,
            Punctuality = 4,
            Responsibility = 5,
            Comment = "Just a great person"
        }
    };

    public void Seed(EntityTypeBuilder<Rating> builder) => builder.HasData(Ratings);
}
