using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class LessonType : ValueObject
{
    private static readonly List<LessonType> _types = [Laboratory, Сonsultation, Lecture, Practice];


    private LessonType(string value)
    {
        Value = value;
    }

    public static LessonType Practice => new("Практическое занятие");
    public static LessonType Lecture => new("Лекция");
    public static LessonType Сonsultation => new("Консультация");
    public static LessonType Laboratory => new("Лабораторная работа");

    public string Value { get; private set; }

    public static Result<LessonType?> Create(string? value)
    {
        if (value == null)
        {
            return Result.Success<LessonType?>(null);
        }

        var newDay = new LessonType(value);

        if (_types.Any(x => x.Value == newDay.Value) == false)
        {
            return Result.Failure<LessonType?>("Неверный формат");
        }

        return Result.Success(newDay)!;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
