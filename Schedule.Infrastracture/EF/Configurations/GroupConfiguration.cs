using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Schedule.Core.Models;
using Schedule.Core.ValueObjects;

namespace Schedule.Infrastracture.EF.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(Group.MaxNameLength);

        builder.Property(g => g.InstitutionName)
            .HasMaxLength(Group.MaxInstitutionNameLength);

        builder.Property(g => g.Description)
            .HasMaxLength(Group.MaxDescriptionLength);

        builder.HasMany(g => g.Members)
            .WithMany(u => u.Groups)
            .UsingEntity(x => x.ToTable("GroupUsers"));

        builder.HasMany(g => g.Lessons)
            .WithOne()
            .HasForeignKey(l => l.GroupId);

        builder.ComplexProperty(g => g.ScheduleFormat, b =>
        {
            b.IsRequired();
            b.Property(n => n.Value)
                .HasColumnName("ScheduleFormat")
                .HasMaxLength(100);
        });

        builder.Navigation(p => p.Members).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Navigation(p => p.Lessons).UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
