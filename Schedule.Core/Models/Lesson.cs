using CSharpFunctionalExtensions;
using Schedule.Core.Enums;
using Schedule.Core.ValueObjects;

namespace Schedule.Core.Models;

public class Lesson : Entity
{
    public const int MaxNameLength = 50;
    public const int MaxTeacherNameLength = 30;
    public const int MaxDescriptionLength = 200;
    public const int MaxAuditoriumLength = 15;

    private Lesson(
        string name,
        long grpupId,
        LessonWeekType weekType,
        LessonTime lessonTime,
        LessonDayOfWeek dayOfWeek,
        LessonType? lessonType,
        string? auditorium,
        string? description,
        string? teacherName)
    {
        Name = name;
        GroupId = grpupId;
        WeekType = weekType;
        DayOfWeek = dayOfWeek;
        LessonTime = lessonTime;
        LessonType = lessonType;
        Auditorium = auditorium;
        Description = description;
        TeacherName = teacherName;
    }

    //Для EF Core
    private Lesson() { }

    public string Name { get; private set; }
    public long GroupId { get; private set; }
    public LessonWeekType WeekType { get; private set; }
    public LessonTime LessonTime { get; private set; }
    public LessonDayOfWeek DayOfWeek { get; private set; }
    public LessonType? LessonType { get; private set; } = null;
    public string? Auditorium { get; private set; } = null;
    public string? Description { get; private set; } = null;
    public string? TeacherName { get; private set; } = null;

    public static Result<Lesson> Create(
        string name,
        long grpupId,
        LessonWeekType weekType,
        LessonTime lessonTime,
        LessonDayOfWeek dayOfWeek,
        LessonType? lessonType,
        string? auditorium = null,
        string? description = null,
        string? teacherName = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(grpupId, nameof(grpupId));

        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Lesson>("Имя занятия не может быть пустым");
        }
        if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
        {
            description = null;
        }
        if (string.IsNullOrEmpty(auditorium) || string.IsNullOrWhiteSpace(auditorium))
        {
            auditorium = null;
        }
        if (string.IsNullOrEmpty(teacherName) || string.IsNullOrWhiteSpace(teacherName))
        {
            auditorium = null;
        }

        var newLesson = new Lesson(name, grpupId, weekType, lessonTime, dayOfWeek, lessonType, auditorium, description, teacherName);
        return Result.Success(newLesson);
    }
}
