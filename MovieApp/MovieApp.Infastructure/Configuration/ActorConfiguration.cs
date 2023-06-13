using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Core.Entities.ActorModels;
using System.Security.Cryptography.X509Certificates;

namespace MovieApp.Infastructure.Configuration;
public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Name).HasMaxLength(25).IsRequired();
        builder.Property(x=>x.BirthName).IsRequired();

        builder.HasOne(x => x.Movies).WithMany(x=>x.Actors).HasForeignKey(x => x.MovieId);
    }
}
