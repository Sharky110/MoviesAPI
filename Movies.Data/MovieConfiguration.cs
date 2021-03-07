using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Core.Models;

namespace Movies.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasKey(m => m.Id);

        //    builder
        //        .Property(m => m.Id)
       //         .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

        //    builder
         //       .HasMany(m => m.Genres)
         //       .WithMany(g => g.Movies)
          //      .UsingEntity(j => j.ToTable("GenreMovie"));
              //  .HasForeignKey(m => m.GenreId);

            builder
                .ToTable("Movies");
        }
    }
}
