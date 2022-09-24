using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamworkSystem.DataAccessLayer.Interfaces.Seeders;

public interface ISeeder<T> where T : class
{
    void Seed(EntityTypeBuilder<T> builder);
}

public interface ISeeder
{
    void Seed(EntityTypeBuilder builder);
}
