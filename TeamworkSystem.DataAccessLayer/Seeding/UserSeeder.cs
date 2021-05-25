using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class UserSeeder : ISeeder<User>
    {
        private static readonly List<(User, string)> users = new()
        {
            (
                new User
                {
                    Id = "3b333929-f974-444e-a8d3-68f50a0459c0",
                    UserName = "User1",
                    FirstName = "Esmaralda",
                    LastName = "Voigt",
                    Profession = "Developer",
                    Specialization = "Frontend"
                },
                "User%password1"
            ),
            (
                new User
                {
                    Id = "61dfb9e3-1c27-424a-9963-9586ca110220",
                    UserName = "User2",
                    FirstName = "Ostap",
                    LastName = "Bleier",
                    Profession = "Tester",
                    Specialization = "Backend"
                },
                "User%password2"
            ),
            (
                new User
                {
                    Id = "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                    UserName = "User3",
                    FirstName = "Sophia",
                    LastName = "Beringer",
                    Profession = null,
                    Specialization = "Fullstack"
                },
                "User%password3"
            ),
            (
                new User
                {
                    Id = "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                    UserName = "User4",
                    FirstName = "Marlyn",
                    LastName = "Hendry",
                    Profession = "Artist",
                    Specialization = null
                },
                "User%password4"
            ),
            (
                new User
                {
                    Id = "ae557ffc-2906-4913-bd26-40aa98a55570",
                    UserName = "User5",
                    FirstName = "Vlasi",
                    LastName = "Arterberry",
                    Profession = "Designer",
                    Specialization = "Interier"
                },
                "User%password5"
            ),
            (
                new User
                {
                    Id = "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                    UserName = "User6",
                    FirstName = "Chasity",
                    LastName = "Ilbert",
                    Profession = null,
                    Specialization = null
                },
                "User%password6"
            ),
            (
                new User
                {
                    Id = "bc0c5522-0a02-4f23-bb6a-319529716a94",
                    UserName = "User7",
                    FirstName = "Seraphina",
                    LastName = "Salmon",
                    Profession = "Developer",
                    Specialization = "Backend"
                },
                "User%password7"
            ),
            (
                new User
                {
                    Id = "7484e532-dc8e-4005-8b67-15ad8a421a37",
                    UserName = "User8",
                    FirstName = "Chas",
                    LastName = "Hope",
                    Profession = "Designer",
                    Specialization = null
                },
                "User%password8"
            ),
            (
                new User
                {
                    Id = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                    UserName = "User9",
                    FirstName = "Nadezhda",
                    LastName = "Haynes",
                    Profession = null,
                    Specialization = null
                },
                "User%password9"
            ),
            (
                new User
                {
                    Id = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                    UserName = "User10",
                    FirstName = "Sonny",
                    LastName = "Gibb",
                    Profession = "Tester",
                    Specialization = null
                },
                "User%password10"
            ),
            (
                new User
                {
                    Id = "0a906f06-fc52-417b-bc81-352df8bbe721",
                    UserName = "User11",
                    FirstName = "Eric",
                    LastName = "Lincoln",
                    Profession = "Designer",
                    Specialization = null
                },
                "User%password11"
            )
        };

        public void Seed(EntityTypeBuilder<User> builder)
        {
            foreach (var (user, password) in users)
            {
                user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);
                builder.HasData(user);
            }
        }
    }
}
