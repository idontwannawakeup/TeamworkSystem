﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.DataAccess.Entities;

namespace TeamworkSystem.Identity.DataAccess;

public class TeamworkSystemIdentityDbContext : IdentityDbContext<User>
{
    public TeamworkSystemIdentityDbContext(DbContextOptions<TeamworkSystemIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}