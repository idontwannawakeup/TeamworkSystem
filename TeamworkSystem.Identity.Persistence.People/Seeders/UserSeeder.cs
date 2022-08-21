using TeamworkSystem.Identity.Persistence.People.Entities;

namespace TeamworkSystem.Identity.Persistence.People.Seeders;

public class UserSeeder
{
    // For all seeded users password is "User%password{number}"
    // where number is number from UserName
    private static readonly List<User> Users = new()
    {
        new User
        {
            Id = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220"),
            UserName = "User1",
            NormalizedUserName = "USER1",
            Email = "user1@gmail.com",
            NormalizedEmail = "USER1@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEHIJxNS71yM2C19K8pJktzIg+gOfmz3ySn59bRPhmSrkabIMpXGGzKjZjhnEjFKqSA==",
            ConcurrencyStamp = "f44736ce-d7d2-41f5-89f7-95919ba4b4fa",
            SecurityStamp = "c58ae9db-4ab1-41d9-acbf-dbd162586983",
            FirstName = "Ostap",
            LastName = "Nice",
            Profession = "Developer",
            Specialization = "Backend"
        },
        new User
        {
            Id = Guid.Parse("3b333929-f974-444e-a8d3-68f50a0459c0"),
            UserName = "User2",
            NormalizedUserName = "USER2",
            Email = "user2@gmail.com",
            NormalizedEmail = "USER2@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEL2BIy+jkeBhvgGn5KGCTBlCMZLv1a/3No9TNsIy4cK+hZX72njK6pgL1GgqPM0PKw==",
            ConcurrencyStamp = "e50a9022-d52a-4380-b83d-f0a475fbf14a",
            SecurityStamp = "b1b368ca-830b-4d51-9088-cca805dbae10",
            FirstName = "Esmaralda",
            LastName = "Voigt",
            Profession = "Developer",
            Specialization = "Frontend"
        },
        new User
        {
            Id = Guid.Parse("a36b02e1-81a9-47f4-89b6-d33c4f40ed5f"),
            UserName = "User3",
            NormalizedUserName = "USER3",
            Email = "user3@gmail.com",
            NormalizedEmail = "USER3@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEO/UmfH8XG+WTNv1ObFBISr3QPkLEIioSGoSE624sdtPr/n0R2CF0QHAxj3nJ20tVQ==",
            ConcurrencyStamp = "337bed17-84eb-40fd-b054-8143c3f2a395",
            SecurityStamp = "fd9d63cf-b341-4a41-9bea-eee95a727210",
            FirstName = "Sophia",
            LastName = "Beringer",
            Profession = null,
            Specialization = "Fullstack"
        },
        new User
        {
            Id = Guid.Parse("013a2014-4a25-4a3d-9fae-e0f783d42ef9"),
            UserName = "User4",
            NormalizedUserName = "USER4",
            Email = "user4@gmail.com",
            NormalizedEmail = "USER4@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEGLBS07wW/31unmQo+9CzPpddy9CAQ9MoJMctGizdmQGkV5wbs8AfOqY4junLa3EHw==",
            ConcurrencyStamp = "9bf32f13-7700-49e6-86db-2a5061d23dac",
            SecurityStamp = "f7cca86c-9d2a-416e-b80c-2c8433bb799d",
            FirstName = "Marlyn",
            LastName = "Hendry",
            Profession = "Artist",
            Specialization = null
        },
        new User
        {
            Id = Guid.Parse("ae557ffc-2906-4913-bd26-40aa98a55570"),
            UserName = "User5",
            NormalizedUserName = "USER5",
            Email = "user5@gmail.com",
            NormalizedEmail = "USER5@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEAR2JdvRPd1tVc+laO+tHhsGmRUodkuSHxiLnsMAu0UEiPSWpOMNOgelabUN5IY8mg==",
            ConcurrencyStamp = "0f9a4766-ce0c-4212-83e3-b5aa91766e41",
            SecurityStamp = "2b429c9a-051e-4853-b1b9-109e9ea1c800",
            FirstName = "Vlasi",
            LastName = "Arterberry",
            Profession = "Designer",
            Specialization = "Interier"
        },
        new User
        {
            Id = Guid.Parse("e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2"),
            UserName = "User6",
            NormalizedUserName = "USER6",
            Email = "user6@gmail.com",
            NormalizedEmail = "USER6@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAECR6b8CpecXVogmitbfkvTOt2PWxVi3+f8ITWxYl8mJ3w4KAcPVV2hHnEZ3oMW1T1A==",
            ConcurrencyStamp = "6a6db53c-46af-4c60-a447-033fd6a1f1c5",
            SecurityStamp = "b4bdbefd-5d8f-4ccd-aa24-5930aa75aa68",
            FirstName = "Chasity",
            LastName = "Ilbert",
            Profession = null,
            Specialization = null
        },
        new User
        {
            Id = Guid.Parse("bc0c5522-0a02-4f23-bb6a-319529716a94"),
            UserName = "User7",
            NormalizedUserName = "USER7",
            Email = "user7@gmail.com",
            NormalizedEmail = "USER7@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEFUDlk3bKxR8CoowzB76pDuzWh5oSL0xvqSGV4iNfPzeUkWLW33K7gDPtSGkkPb5sg==",
            ConcurrencyStamp = "a5c49d1a-19e7-45fe-8dd9-9f9554aa5e45",
            SecurityStamp = "486d413e-645c-4682-80ef-ff00375c60b1",
            FirstName = "Seraphina",
            LastName = "Salmon",
            Profession = "Developer",
            Specialization = "Backend"
        },
        new User
        {
            Id = Guid.Parse("7484e532-dc8e-4005-8b67-15ad8a421a37"),
            UserName = "User8",
            NormalizedUserName = "USER8",
            Email = "user8@gmail.com",
            NormalizedEmail = "USER8@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEDMlNkhUX9Tv8m1WoKR/a5ih0hIAz/YvPiN4O33OyOtaFmYU4AkLWH5rDE1KbqgfBQ==",
            ConcurrencyStamp = "dc22b52f-696d-43a2-aadc-5cd3127af882",
            SecurityStamp = "66c2ff61-d8df-44d0-b0bf-20da42d4dda8",
            FirstName = "Chas",
            LastName = "Hope",
            Profession = "Designer",
            Specialization = null
        },
        new User
        {
            Id = Guid.Parse("3f036c83-88e8-4aeb-ad33-290d60cf6b66"),
            UserName = "User9",
            NormalizedUserName = "USER9",
            Email = "user9@gmail.com",
            NormalizedEmail = "USER9@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEMujOiZ+xyXQzQ0BQaFPacbSywrVpM/kUyOVkLpqjnyqpNL5iPFSh4pQuXALTAzDzg==",
            ConcurrencyStamp = "94cb97ce-bd4e-4a74-912b-fb0562cf8d98",
            SecurityStamp = "7c33daa4-c288-436c-9f48-d5316bdf21f7",
            FirstName = "Nadezhda",
            LastName = "Haynes",
            Profession = null,
            Specialization = null
        },
        new User
        {
            Id = Guid.Parse("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
            UserName = "User10",
            NormalizedUserName = "USER10",
            Email = "user10@gmail.com",
            NormalizedEmail = "USER10@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEBpXFqORoIAZzf4ecLwpafHOApLBaIaX+GKlPCrl5uUpwZVtE9ihjJv0JFsq9/ObLw==",
            ConcurrencyStamp = "e5197c13-324a-4de3-814f-fbd0466b4a3c",
            SecurityStamp = "3c9bec94-dd50-4ee4-8f5e-be1e84ea8c86",
            FirstName = "Sonny",
            LastName = "Gibb",
            Profession = "Tester",
            Specialization = null
        },
        new User
        {
            Id = Guid.Parse("0a906f06-fc52-417b-bc81-352df8bbe721"),
            UserName = "User11",
            NormalizedUserName = "USER11",
            Email = "user11@gmail.com",
            NormalizedEmail = "USER11@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEMYbmSdr5+9v1sDNj+0f+c1+DmI0ugPnbtFMx3ONkWszAGHfFhZdWO4XZvvDjemq1w==",
            ConcurrencyStamp = "a8e49c32-6b6a-4e06-ac96-f683fa8a0df5",
            SecurityStamp = "370697bb-d75e-42da-9560-b182cb28aaa3",
            FirstName = "Eric",
            LastName = "Lincoln",
            Profession = "Designer",
            Specialization = null
        }
    };

    public static void Seed(PeopleDbContext context)
    {
        context.Users.AddRange(Users);
    }
}
