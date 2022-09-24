﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamworkSystem.WorkManagement.Persistence;

#nullable disable

namespace TeamworkSystem.WorkManagement.Persistence.Migrations
{
    [DbContext(typeof(WorkManagementDbContext))]
    partial class WorkManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TeamUserProfile", b =>
                {
                    b.Property<Guid>("MembersId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<Guid>("TeamsId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TeamId");

                    b.HasKey("MembersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("TeamsMembers", (string)null);

                    b.HasData(
                        new
                        {
                            MembersId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            TeamsId = new Guid("73d936ae-0269-475d-b58f-8b456fafce85")
                        },
                        new
                        {
                            MembersId = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            TeamsId = new Guid("80e2fd08-759c-42fa-a25b-ae8252d13ca6")
                        },
                        new
                        {
                            MembersId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            TeamsId = new Guid("12b4ec07-1d5f-4baf-9237-a3b19a5b7a68")
                        },
                        new
                        {
                            MembersId = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            TeamsId = new Guid("79d2e324-7cae-4cb5-b039-27d2c07ce517")
                        },
                        new
                        {
                            MembersId = new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"),
                            TeamsId = new Guid("5b78adfd-017f-4b97-b7a3-06dc54813dc2")
                        },
                        new
                        {
                            MembersId = new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
                            TeamsId = new Guid("29c1751d-6a4b-405d-9268-0863a4b0e196")
                        },
                        new
                        {
                            MembersId = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            TeamsId = new Guid("7ade466f-f4b1-4bc9-8e41-6fac1a1b8b01")
                        },
                        new
                        {
                            MembersId = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            TeamsId = new Guid("d08c11eb-ecf6-47b6-9276-bbc46275f919")
                        },
                        new
                        {
                            MembersId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            TeamsId = new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9")
                        },
                        new
                        {
                            MembersId = new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
                            TeamsId = new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9")
                        },
                        new
                        {
                            MembersId = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            TeamsId = new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9")
                        });
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("ntext");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("2f73e5de-7fb3-47c1-9756-ea8a499d8eac"),
                            Description = "Just a simple blog from small team",
                            TeamId = new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9"),
                            Title = "Blog",
                            Type = "Website"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("ntext");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LeaderId")
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("73d936ae-0269-475d-b58f-8b456fafce85"),
                            About = "Young and ambitious",
                            LeaderId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            Name = "Amigos",
                            Specialization = "Web Development"
                        },
                        new
                        {
                            Id = new Guid("80e2fd08-759c-42fa-a25b-ae8252d13ca6"),
                            LeaderId = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            Name = "Heatwave",
                            Specialization = "OblEnergo"
                        },
                        new
                        {
                            Id = new Guid("12b4ec07-1d5f-4baf-9237-a3b19a5b7a68"),
                            About = "Lazy guys",
                            LeaderId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            Name = "Lazy Guys",
                            Specialization = "Design"
                        },
                        new
                        {
                            Id = new Guid("79d2e324-7cae-4cb5-b039-27d2c07ce517"),
                            LeaderId = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            Name = "Champions"
                        },
                        new
                        {
                            Id = new Guid("5b78adfd-017f-4b97-b7a3-06dc54813dc2"),
                            LeaderId = new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"),
                            Name = "Legends"
                        },
                        new
                        {
                            Id = new Guid("29c1751d-6a4b-405d-9268-0863a4b0e196"),
                            LeaderId = new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
                            Name = "Shakedown"
                        },
                        new
                        {
                            Id = new Guid("7ade466f-f4b1-4bc9-8e41-6fac1a1b8b01"),
                            About = "We are the warriors",
                            LeaderId = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            Name = "Warriors"
                        },
                        new
                        {
                            Id = new Guid("d08c11eb-ecf6-47b6-9276-bbc46275f919"),
                            About = "We are the defenders",
                            LeaderId = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            Name = "Defenders",
                            Specialization = "Tests"
                        },
                        new
                        {
                            Id = new Guid("1ee4f75c-099d-4de3-a298-7d5ed17556f9"),
                            About = "We are writing bugs, fear us",
                            LeaderId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            Name = "Thunder",
                            Specialization = "Writing bugs"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<Guid?>("ExecutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("61c21020-30a0-47a6-8b9d-607b6b9f68b0"),
                            CreationTime = new DateTime(2022, 6, 1, 13, 57, 3, 0, DateTimeKind.Unspecified),
                            Description = "There's unknown bug. Just fix it.",
                            ExecutorId = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            Priority = "Medium",
                            ProjectId = new Guid("2f73e5de-7fb3-47c1-9756-ea8a499d8eac"),
                            Status = "Backlog",
                            Title = "Fix bug",
                            Type = "Epic"
                        });
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Profession")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Specialization")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("61dfb9e3-1c27-424a-9963-9586ca110220"),
                            FirstName = "Ostap",
                            LastName = "Nice",
                            Profession = "Developer",
                            Specialization = "Backend"
                        },
                        new
                        {
                            Id = new Guid("3b333929-f974-444e-a8d3-68f50a0459c0"),
                            FirstName = "Esmaralda",
                            LastName = "Voigt",
                            Profession = "Developer",
                            Specialization = "Frontend"
                        },
                        new
                        {
                            Id = new Guid("a36b02e1-81a9-47f4-89b6-d33c4f40ed5f"),
                            FirstName = "Sophia",
                            LastName = "Beringer",
                            Specialization = "Fullstack"
                        },
                        new
                        {
                            Id = new Guid("013a2014-4a25-4a3d-9fae-e0f783d42ef9"),
                            FirstName = "Marlyn",
                            LastName = "Hendry",
                            Profession = "Artist"
                        },
                        new
                        {
                            Id = new Guid("ae557ffc-2906-4913-bd26-40aa98a55570"),
                            FirstName = "Vlasi",
                            LastName = "Arterberry",
                            Profession = "Designer",
                            Specialization = "Interier"
                        },
                        new
                        {
                            Id = new Guid("e5ca09a8-d3c6-4114-99a0-6b2f86ff1df2"),
                            FirstName = "Chasity",
                            LastName = "Ilbert"
                        },
                        new
                        {
                            Id = new Guid("bc0c5522-0a02-4f23-bb6a-319529716a94"),
                            FirstName = "Seraphina",
                            LastName = "Salmon",
                            Profession = "Developer",
                            Specialization = "Backend"
                        },
                        new
                        {
                            Id = new Guid("7484e532-dc8e-4005-8b67-15ad8a421a37"),
                            FirstName = "Chas",
                            LastName = "Hope",
                            Profession = "Designer"
                        },
                        new
                        {
                            Id = new Guid("3f036c83-88e8-4aeb-ad33-290d60cf6b66"),
                            FirstName = "Nadezhda",
                            LastName = "Haynes"
                        },
                        new
                        {
                            Id = new Guid("7ad5c481-f391-45bb-a79c-cfcb1adb448b"),
                            FirstName = "Sonny",
                            LastName = "Gibb",
                            Profession = "Tester"
                        },
                        new
                        {
                            Id = new Guid("0a906f06-fc52-417b-bc81-352df8bbe721"),
                            FirstName = "Eric",
                            LastName = "Lincoln",
                            Profession = "Designer"
                        });
                });

            modelBuilder.Entity("TeamUserProfile", b =>
                {
                    b.HasOne("TeamworkSystem.WorkManagement.Domain.Entities.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamworkSystem.WorkManagement.Domain.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Project", b =>
                {
                    b.HasOne("TeamworkSystem.WorkManagement.Domain.Entities.Team", "Team")
                        .WithMany("Projects")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Projects_TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Team", b =>
                {
                    b.HasOne("TeamworkSystem.WorkManagement.Domain.Entities.UserProfile", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Teams_LeaderId");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("TeamworkSystem.WorkManagement.Domain.Entities.UserProfile", "Executor")
                        .WithMany("Tickets")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("FK_Tickets_ExecutorId");

                    b.HasOne("TeamworkSystem.WorkManagement.Domain.Entities.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tickets_ProjectId");

                    b.Navigation("Executor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Project", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.Team", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("TeamworkSystem.WorkManagement.Domain.Entities.UserProfile", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}