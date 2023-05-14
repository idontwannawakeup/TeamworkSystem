using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class RatingSeeder : ISeeder<Rating>
    {
        private static readonly List<Rating> ratings = new()
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
            },
            new Rating
            {
                Id = 2,
                FromId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                ToId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                Social = 4,
                Skills = 4,
                Punctuality = 4,
                Responsibility = 4,
                Comment = "She always comes prepared for meetings and offers great insights. She's a real asset to the team."
            },
            new Rating
            {
                Id = 3,
                FromId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                ToId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Social = 4,
                Skills = 5,
                Punctuality = 3,
                Responsibility = 5,
                Comment = "Their problem-solving skills are impressive. If there's a difficult issue, they're usually the one who finds a solution."
            },
            new Rating
            {
                Id = 4,
                FromId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                ToId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                Social = 0,
                Skills = 0,
                Punctuality = 0,
                Responsibility = 0,
                Comment = "The way they handle stress is commendable. Even in high-pressure situations, they remain calm and focused."
            },
            new Rating
            {
                Id = 5,
                FromId = "7484e532-dc8e-4005-8b67-15ad8a421a37",
                ToId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                Social = 3,
                Skills = 2,
                Punctuality = 4,
                Responsibility = 3,
                Comment = "Their creativity is a breath of fresh air. They often come up with innovative ideas that drive our projects forward."
            },
            new Rating
            {
                Id = 6,
                FromId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                ToId = "bc0c5522-0a02-4f23-bb6a-319529716a94",
                Social = 5,
                Skills = 3,
                Punctuality = 3,
                Responsibility = 4,
                Comment = "They're excellent at collaboration. Always open to feedback and willing to lend a helping hand when someone needs it."
            },
            new Rating
            {
                Id = 7,
                FromId = "bc0c5522-0a02-4f23-bb6a-319529716a94",
                ToId = "ae557ffc-2906-4913-bd26-40aa98a55570",
                Social = 2,
                Skills = 4,
                Punctuality = 5,
                Responsibility = 5,
                Comment = "Their leadership skills are truly impressive. They know how to inspire the team and keep everyone motivated."
            },
            new Rating
            {
                Id = 8,
                FromId = "bc0c5522-0a02-4f23-bb6a-319529716a94",
                ToId = "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                Social = 1,
                Skills = 5,
                Punctuality = 2,
                Responsibility = 5,
                Comment = "Their attention to detail is remarkable. They always ensure our work is accurate and of the highest quality."
            },
            new Rating
            {
                Id = 9,
                FromId = "ae557ffc-2906-4913-bd26-40aa98a55570",
                ToId = "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                Social = 5,
                Skills = 4,
                Punctuality = 3,
                Responsibility = 4,
                Comment = "They have superb communication skills. They're very effective in making sure everyone is on the same page."
            },
            new Rating
            {
                Id = 10,
                FromId = "0a906f06-fc52-417b-bc81-352df8bbe721",
                ToId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                Social = 3,
                Skills = 5,
                Punctuality = 5,
                Responsibility = 5,
                Comment = "Their work ethic is inspiring. Always one of the first to arrive and the last to leave, setting a great example for the team."
            },
            new Rating
            {
                Id = 11,
                FromId = "0a906f06-fc52-417b-bc81-352df8bbe721",
                ToId = "7484e532-dc8e-4005-8b67-15ad8a421a37",
                Social = 5,
                Skills = 2,
                Punctuality = 3,
                Responsibility = 3,
                Comment = "Their positivity is contagious. They always maintain a good attitude, which really helps to boost morale in the office."
            },
        };

        public void Seed(EntityTypeBuilder<Rating> builder) => builder.HasData(ratings);
    }
}
