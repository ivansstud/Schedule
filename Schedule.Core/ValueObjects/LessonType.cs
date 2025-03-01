using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class LessonType : ValueObject
{
    private LessonType(string value)
    {
        Value = value;
    }

    public static LessonType Practice => new("Практическое занятие");
    public static LessonType Lecture => new("Лекция");
    public static LessonType Сonsultation => new("Консультация");
    public static LessonType Laboratory => new("Лабораторная работа");

    public string Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
