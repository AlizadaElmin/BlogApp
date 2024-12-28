using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApp.DAL.Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasIndex(c => c.Name)
            .IsUnique();
        builder.Property(c => c.Name)
            .HasMaxLength(32);
        builder.Property(x=>x.Icon)
            .HasMaxLength(128);
    }
}