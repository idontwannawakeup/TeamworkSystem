using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Interfaces.Seeders;

namespace TeamworkSystem.Social.DataAccess.Seeders;

public class RatingSeeder : IRatingSeeder
{
    private static readonly List<Rating> Ratings = new()
    {
        new Rating
        {
            Id = Guid.Parse("05fa2b57-f3cb-4053-bd7a-d4a3669b596f"),
            FromId = Guid.Parse("3b333929-f974-444e-a8d3-68f50a0459c0"),
            ToId = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220"),
            Social = 5,
            Skills = 5,
            Punctuality = 4,
            Responsibility = 5,
            Comment = "Just a great person"
        }
    };

    public void Seed(EntityTypeBuilder<Rating> builder) => builder.HasData(Ratings);
}
