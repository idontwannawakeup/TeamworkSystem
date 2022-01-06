using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Seeders;

namespace TeamworkSystem.DataAccessLayer.Seeders;

public class UserSeeder : IUserSeeder
{
    // For all seeded users password is "User%password{number}"
    // where number is number from UserName
    private static readonly List<User> Users = new()
    {
        new User
        {
            Id = "61dfb9e3-1c27-424a-9963-9586ca110220",
            UserName = "User1",
            NormalizedUserName = "USER1",
            Email = "user1@gmail.com",
            NormalizedEmail = "USER1@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEHIJxNS71yM2C19K8pJktzIg+gOfmz3ySn59bRPhmSrkabIMpXGGzKjZjhnEjFKqSA==",
            FirstName = "Ostap",
            LastName = "Nice",
            Profession = "Developer",
            Specialization = "Backend"
        },
        new User
        {
            Id = "3b333929-f974-444e-a8d3-68f50a0459c0",
            UserName = "User2",
            NormalizedUserName = "USER2",
            Email = "user2@gmail.com",
            NormalizedEmail = "USER2@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEL2BIy+jkeBhvgGn5KGCTBlCMZLv1a/3No9TNsIy4cK+hZX72njK6pgL1GgqPM0PKw==",
            FirstName = "Esmaralda",
            LastName = "Voigt",
            Profession = "Developer",
            Specialization = "Frontend"
        },
        new User
        {
            Id = "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
            UserName = "User3",
            NormalizedUserName = "USER3",
            Email = "user3@gmail.com",
            NormalizedEmail = "USER3@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEO/UmfH8XG+WTNv1ObFBISr3QPkLEIioSGoSE624sdtPr/n0R2CF0QHAxj3nJ20tVQ==",
            FirstName = "Sophia",
            LastName = "Beringer",
            Profession = null,
            Specialization = "Fullstack"
        },
        new User
        {
            Id = "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
            UserName = "User4",
            NormalizedUserName = "USER4",
            Email = "user4@gmail.com",
            NormalizedEmail = "USER4@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEGLBS07wW/31unmQo+9CzPpddy9CAQ9MoJMctGizdmQGkV5wbs8AfOqY4junLa3EHw==",
            FirstName = "Marlyn",
            LastName = "Hendry",
            Profession = "Artist",
            Specialization = null
        },
        new User
        {
            Id = "ae557ffc-2906-4913-bd26-40aa98a55570",
            UserName = "User5",
            NormalizedUserName = "USER5",
            Email = "user5@gmail.com",
            NormalizedEmail = "USER5@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEAR2JdvRPd1tVc+laO+tHhsGmRUodkuSHxiLnsMAu0UEiPSWpOMNOgelabUN5IY8mg==",
            FirstName = "Vlasi",
            LastName = "Arterberry",
            Profession = "Designer",
            Specialization = "Interier"
        },
        new User
        {
            Id = "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
            UserName = "User6",
            NormalizedUserName = "USER6",
            Email = "user6@gmail.com",
            NormalizedEmail = "USER6@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAECR6b8CpecXVogmitbfkvTOt2PWxVi3+f8ITWxYl8mJ3w4KAcPVV2hHnEZ3oMW1T1A==",
            FirstName = "Chasity",
            LastName = "Ilbert",
            Profession = null,
            Specialization = null
        },
        new User
        {
            Id = "bc0c5522-0a02-4f23-bb6a-319529716a94",
            UserName = "User7",
            NormalizedUserName = "USER7",
            Email = "user7@gmail.com",
            NormalizedEmail = "USER7@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEFUDlk3bKxR8CoowzB76pDuzWh5oSL0xvqSGV4iNfPzeUkWLW33K7gDPtSGkkPb5sg==",
            FirstName = "Seraphina",
            LastName = "Salmon",
            Profession = "Developer",
            Specialization = "Backend"
        },
        new User
        {
            Id = "7484e532-dc8e-4005-8b67-15ad8a421a37",
            UserName = "User8",
            NormalizedUserName = "USER8",
            Email = "user8@gmail.com",
            NormalizedEmail = "USER8@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEDMlNkhUX9Tv8m1WoKR/a5ih0hIAz/YvPiN4O33OyOtaFmYU4AkLWH5rDE1KbqgfBQ==",
            FirstName = "Chas",
            LastName = "Hope",
            Profession = "Designer",
            Specialization = null
        },
        new User
        {
            Id = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
            UserName = "User9",
            NormalizedUserName = "USER9",
            Email = "user9@gmail.com",
            NormalizedEmail = "USER9@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEMujOiZ+xyXQzQ0BQaFPacbSywrVpM/kUyOVkLpqjnyqpNL5iPFSh4pQuXALTAzDzg==",
            FirstName = "Nadezhda",
            LastName = "Haynes",
            Profession = null,
            Specialization = null
        },
        new User
        {
            Id = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
            UserName = "User10",
            NormalizedUserName = "USER10",
            Email = "user10@gmail.com",
            NormalizedEmail = "USER10@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEBpXFqORoIAZzf4ecLwpafHOApLBaIaX+GKlPCrl5uUpwZVtE9ihjJv0JFsq9/ObLw==",
            FirstName = "Sonny",
            LastName = "Gibb",
            Profession = "Tester",
            Specialization = null
        },
        new User
        {
            Id = "0a906f06-fc52-417b-bc81-352df8bbe721",
            UserName = "User11",
            NormalizedUserName = "USER11",
            Email = "user11@gmail.com",
            NormalizedEmail = "USER11@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEMYbmSdr5+9v1sDNj+0f+c1+DmI0ugPnbtFMx3ONkWszAGHfFhZdWO4XZvvDjemq1w==",
            FirstName = "Eric",
            LastName = "Lincoln",
            Profession = "Designer",
            Specialization = null
        }
    };

    public void Seed(EntityTypeBuilder<User> builder) => builder.HasData(Users);
}
