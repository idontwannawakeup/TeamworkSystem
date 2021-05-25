﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamworkSystem.DataAccessLayer;

namespace TeamworkSystem.DataAccessLayer.Migrations
{
    [DbContext(typeof(TeamworkSystemContext))]
    partial class TeamworkSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TeamUser", b =>
                {
                    b.Property<string>("MembersId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserId");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int")
                        .HasColumnName("TeamId");

                    b.HasKey("MembersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("TeamsMembers");
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Just a simple blog from small team",
                            TeamId = 9,
                            Title = "Blog",
                            Type = "Website"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("ntext");

                    b.Property<string>("FromId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Punctuality")
                        .HasColumnType("int");

                    b.Property<int>("Responsibility")
                        .HasColumnType("int");

                    b.Property<int>("Skills")
                        .HasColumnType("int");

                    b.Property<int>("Social")
                        .HasColumnType("int");

                    b.Property<string>("ToId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("FromId", "ToId")
                        .HasName("AK_Ratings_FromId_ToId");

                    b.HasIndex("ToId");

                    b.ToTable("Ratings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Just a great person",
                            FromId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                            Punctuality = 4,
                            Responsibility = 5,
                            Skills = 5,
                            Social = 5,
                            ToId = "61dfb9e3-1c27-424a-9963-9586ca110220"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasColumnType("ntext");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Specialization")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LeaderId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            About = "Young and ambitious",
                            LeaderId = "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                            Name = "Amigos",
                            Specialization = "Web Development"
                        },
                        new
                        {
                            Id = 2,
                            LeaderId = "0a906f06-fc52-417b-bc81-352df8bbe721",
                            Name = "Heatwave",
                            Specialization = "OblEnergo"
                        },
                        new
                        {
                            Id = 3,
                            About = "Lazy guys",
                            LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                            Name = "Lazy Guys",
                            Specialization = "Design"
                        },
                        new
                        {
                            Id = 4,
                            LeaderId = "0a906f06-fc52-417b-bc81-352df8bbe721",
                            Name = "Champions"
                        },
                        new
                        {
                            Id = 5,
                            LeaderId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                            Name = "Legends"
                        },
                        new
                        {
                            Id = 6,
                            LeaderId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                            Name = "Shakedown"
                        },
                        new
                        {
                            Id = 7,
                            About = "We are the warriors",
                            LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                            Name = "Warriors"
                        },
                        new
                        {
                            Id = 8,
                            About = "We are the defenders",
                            LeaderId = "3b333929-f974-444e-a8d3-68f50a0459c0",
                            Name = "Defenders",
                            Specialization = "Tests"
                        },
                        new
                        {
                            Id = 9,
                            About = "We are writing bugs, fear us",
                            LeaderId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                            Name = "Thunder",
                            Specialization = "Writing bugs"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("ExecutorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationTime = new DateTime(2021, 5, 25, 11, 22, 24, 884, DateTimeKind.Local).AddTicks(6378),
                            Description = "There's unknown bug. Just fix it.",
                            ExecutorId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                            Priority = "Medium",
                            ProjectId = 1,
                            Status = "Backlog",
                            Title = "Fix bug",
                            Type = "Epic"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Profession")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "3b333929-f974-444e-a8d3-68f50a0459c0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "30487bd1-d3a6-4e3c-9b9d-7745ca79787a",
                            EmailConfirmed = false,
                            FirstName = "Esmaralda",
                            LastName = "Voigt",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Developer",
                            SecurityStamp = "7e39ba04-9d04-4d18-947d-de890ed90e56",
                            Specialization = "Frontend",
                            TwoFactorEnabled = false,
                            UserName = "User1"
                        },
                        new
                        {
                            Id = "61dfb9e3-1c27-424a-9963-9586ca110220",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "799f0bc2-f54b-4618-b56d-4f6b47224cdd",
                            EmailConfirmed = false,
                            FirstName = "Ostap",
                            LastName = "Bleier",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Tester",
                            SecurityStamp = "5ae0377e-83e8-4dab-84a1-425d56c52fae",
                            Specialization = "Backend",
                            TwoFactorEnabled = false,
                            UserName = "User2"
                        },
                        new
                        {
                            Id = "a36b02e1-81a9-47f4-89b6-d33c4f40ed5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2637f8ab-b415-4d9c-bf41-1b75ab8f5b45",
                            EmailConfirmed = false,
                            FirstName = "Sophia",
                            LastName = "Beringer",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "27e12c3e-9b28-4799-9165-5e52229b5595",
                            Specialization = "Fullstack",
                            TwoFactorEnabled = false,
                            UserName = "User3"
                        },
                        new
                        {
                            Id = "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "78e964b8-cd74-4e51-a3a4-66e991262562",
                            EmailConfirmed = false,
                            FirstName = "Marlyn",
                            LastName = "Hendry",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Artist",
                            SecurityStamp = "99276256-def5-40d2-b368-14ae49374744",
                            TwoFactorEnabled = false,
                            UserName = "User4"
                        },
                        new
                        {
                            Id = "ae557ffc-2906-4913-bd26-40aa98a55570",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8d5ef861-3f7a-469b-b310-77465f784c74",
                            EmailConfirmed = false,
                            FirstName = "Vlasi",
                            LastName = "Arterberry",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Designer",
                            SecurityStamp = "8ecc0a3e-2662-403b-abfa-c77c26277100",
                            Specialization = "Interier",
                            TwoFactorEnabled = false,
                            UserName = "User5"
                        },
                        new
                        {
                            Id = "e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a9ee1fa3-988b-4c16-9f55-068a7f3dbf84",
                            EmailConfirmed = false,
                            FirstName = "Chasity",
                            LastName = "Ilbert",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "37aeabaa-4d09-477f-9fd2-9ccecab98562",
                            TwoFactorEnabled = false,
                            UserName = "User6"
                        },
                        new
                        {
                            Id = "bc0c5522-0a02-4f23-bb6a-319529716a94",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3eefbd2a-9b44-4a1a-87fb-371ba050e636",
                            EmailConfirmed = false,
                            FirstName = "Seraphina",
                            LastName = "Salmon",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Developer",
                            SecurityStamp = "a832cdbd-6eae-4e0e-b8eb-2adf140aba87",
                            Specialization = "Backend",
                            TwoFactorEnabled = false,
                            UserName = "User7"
                        },
                        new
                        {
                            Id = "7484e532-dc8e-4005-8b67-15ad8a421a37",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e1c2c990-1a12-44b3-89e4-947e119b4dad",
                            EmailConfirmed = false,
                            FirstName = "Chas",
                            LastName = "Hope",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Designer",
                            SecurityStamp = "4633a032-241a-4dbd-bf58-2be53bf7d922",
                            TwoFactorEnabled = false,
                            UserName = "User8"
                        },
                        new
                        {
                            Id = "3f036c83-88e8-4aeb-ad33-290d60cf6b66",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b2c643a0-f118-4cfe-a59b-bd1b8ace624e",
                            EmailConfirmed = false,
                            FirstName = "Nadezhda",
                            LastName = "Haynes",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "12ec1f1e-3194-4895-9394-d925bc5bb5c4",
                            TwoFactorEnabled = false,
                            UserName = "User9"
                        },
                        new
                        {
                            Id = "7ad5c481-f391-45bb-a79c-cfcb1adb448b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5d263f3b-b5e0-4128-9506-d84fae26682d",
                            EmailConfirmed = false,
                            FirstName = "Sonny",
                            LastName = "Gibb",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Tester",
                            SecurityStamp = "d362dfe4-06ab-4bf8-9c92-97973691b23d",
                            TwoFactorEnabled = false,
                            UserName = "User10"
                        },
                        new
                        {
                            Id = "0a906f06-fc52-417b-bc81-352df8bbe721",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e576c01f-53a9-4c30-a143-cd2005f537dd",
                            EmailConfirmed = false,
                            FirstName = "Eric",
                            LastName = "Lincoln",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            Profession = "Designer",
                            SecurityStamp = "1865d845-aa3b-4efc-881c-b54d6589b4b0",
                            TwoFactorEnabled = false,
                            UserName = "User11"
                        });
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<string>("FriendForUsersId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("SecondId");

                    b.Property<string>("FriendsId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("FirstId");

                    b.HasKey("FriendForUsersId", "FriendsId");

                    b.HasIndex("FriendsId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamUser", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Project", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK_Projects_TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Rating", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", "From")
                        .WithMany("MyRatings")
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK_Ratings_FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", "To")
                        .WithMany("RatingsFromMe")
                        .HasForeignKey("ToId")
                        .HasConstraintName("FK_Ratings_ToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Team", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId")
                        .HasConstraintName("FK_Teams_LeaderId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Ticket", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", "Executor")
                        .WithMany("Tickets")
                        .HasForeignKey("ExecutorId")
                        .HasConstraintName("FK_Tickets_ExecutorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Tickets_ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FriendForUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamworkSystem.DataAccessLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("FriendsId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Project", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.Team", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("TeamworkSystem.DataAccessLayer.Entities.User", b =>
                {
                    b.Navigation("MyRatings");

                    b.Navigation("RatingsFromMe");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
