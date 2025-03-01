using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Schedule.Core.Models;
using Schedule.Core.Enums;

namespace Schedule.Infrastracture.EF.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.Name).IsRequired();
        builder.Property(l => l.GroupId).IsRequired();

        builder.Property(l => l.WeekType)
            .IsRequired()
            .HasConversion(
                wt => wt.ToString(),  // Преобразование Enum -> String
                wt => (LessonWeekType)Enum.Parse(typeof(LessonWeekType), wt) // Преобразование String -> Enum
            );

        builder.Property(l => l.Auditorium).HasMaxLength(Lesson.MaxAuditoriumLength);
        builder.Property(l => l.Description).HasMaxLength(Lesson.MaxAuditoriumLength);
        builder.Property(l => l.TeacherName).HasMaxLength(Lesson.MaxTeacherNameLength);

        builder.ComplexProperty(l => l.LessonTime, b =>
        {
            b.Property(t => t.StartTime)
                .HasColumnName("start_time")
                .IsRequired();
            b.Property(t => t.EndTime)
                .HasColumnName("end_time")
                .IsRequired();
        });

        builder.ComplexProperty(l => l.DayOfWeek, b =>
        {
            b.IsRequired();
            b.Property(d => d.Value)
                .HasColumnName("day")
                .HasMaxLength(100);
        });

        builder.ComplexProperty(l => l.LessonType, b =>
        {
            b.IsRequired();
            b.Property(ltype => ltype.Value)
                .HasColumnName("type")
                .HasMaxLength(100);
        });
    }
}
