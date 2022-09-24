using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Social.DataAccess.Data.Entities;
using TeamworkSystem.Social.DataAccess.Data.Seeders;

namespace TeamworkSystem.Social.DataAccess.Data.Configurations;

public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.Property(rating => rating.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(rating => rating.Social)
               .IsRequired();

        builder.Property(rating => rating.Skills)
               .IsRequired();

        builder.Property(rating => rating.Responsibility)
               .IsRequired();

        builder.Property(rating => rating.Punctuality)
               .IsRequired();

        builder.Property(rating => rating.Comment)
               .HasColumnType("ntext");

        builder.HasAlternateKey(rating => new { rating.FromId, rating.ToId })
               .HasName("AK_Ratings_FromId_ToId");

        builder.HasOne(rating => rating.From)
               .WithMany(user => user.MyRatings)
               .HasForeignKey(rating => rating.FromId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Ratings_FromId");

        builder.HasOne(rating => rating.To)
               .WithMany(user => user.RatingsFromMe)
               .HasForeignKey(rating => rating.ToId)
               .OnDelete(DeleteBehavior.NoAction)
               .HasConstraintName("FK_Ratings_ToId");

        new RatingSeeder().Seed(builder);
    }
}
