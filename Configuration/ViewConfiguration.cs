using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandoLogic.Models;

namespace PandoLogic.Configuration;

public class ViewConfiguration: IEntityTypeConfiguration<View>
{
    public void Configure(EntityTypeBuilder<View> builder)
    {
        builder.ToTable("views");

        builder.Property(_ => _.Id)
            .HasColumnName("id");
        builder.HasKey(_ => _.Id);
        
        builder.HasOne(_ => _.Job)
            .WithMany(_ => _.Views)
            .HasForeignKey("job_id");

        builder.Property(_ => _.ViewDate)
         .HasColumnName("view_date")
         .HasColumnType("datetime");
    }
}