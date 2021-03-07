using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(rating => rating.Social)
                .IsRequired();

            builder.Property(rating => rating.Skills)
                .IsRequired();

            builder.Property(rating => rating.Comment)
                .HasColumnType("ntext");

            builder.HasKey(rating => new { rating.FromId, rating.ToId })
                .HasName("PK_Ratings_From_To");

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
        }
    }
}
