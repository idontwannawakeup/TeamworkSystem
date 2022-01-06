using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeamworkSystem.DataAccessLayer.Interfaces;

public interface ISeeder<T> where T : class
{
    void Seed(EntityTypeBuilder<T> builder);
}
