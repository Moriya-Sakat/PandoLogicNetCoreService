using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandoLogic.Models;

namespace PandoLogic.Configuration;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("jobs");

        builder.Property(_ => _.Id)
            .HasColumnName("id");
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.CreationTime)
            .HasColumnName("creation_time")
            .HasColumnType("datetime");

        builder.HasMany(_ => _.Views)
            .WithOne(_ => _.Job);

        builder.Property(_ => _.IsActive)
            .HasColumnName("is_active");
    }
}