using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Core.Entities;
using MovieApp.Core.Entities.GenreModels;

namespace MovieApp.Infastructure.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Name).HasMaxLength(30).IsRequired();   
        builder.Property(x=>x.Description).HasMaxLength(300).IsRequired();

        builder.HasMany(x => x.MovieGenres).WithOne(x => x.Genre).HasForeignKey(x => x.GenreId);
    }
}
