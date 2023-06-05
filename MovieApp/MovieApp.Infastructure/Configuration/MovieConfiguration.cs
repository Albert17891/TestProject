using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Core.Entities;

namespace MovieApp.Infastructure.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Name).IsRequired();
        builder.Property(x=>x.Description).IsRequired();
        builder.Property(x => x.CreatedDate).IsRequired();

        builder.HasData(new Movie
        {
            Id = 1,
            Name = "Test",
            Description = "Some Test",
            CreatedDate = DateTime.Now,
        });
    }
}
