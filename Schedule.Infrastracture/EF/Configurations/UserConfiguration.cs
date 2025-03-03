using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Schedule.Core.Models;
using Schedule.Core.ValueObjects;

namespace Schedule.Infrastracture.EF.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.TelegramId).IsRequired();

        builder.HasMany(u => u.Groups)
            .WithMany(g => g.Members)
            .UsingEntity(x => x.ToTable("GroupUsers"));

        builder.HasMany(u => u.CreatedGroups)
            .WithOne(g => g.Creator)
            .HasForeignKey(g => g.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ComplexProperty(p => p.Name, b =>
        {
            b.IsRequired();
            b.Property(n => n.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(UserName.MaxLength);
            b.Property(n => n.SecondName)
                .HasColumnName("SecondName")
                .HasMaxLength(UserName.MaxLength);
        });

        builder.Navigation(p => p.Groups).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(p => p.CreatedGroups).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
