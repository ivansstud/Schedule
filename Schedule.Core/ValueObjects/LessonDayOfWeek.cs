using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class LessonDayOfWeek : ValueObject
{
    private LessonDayOfWeek(string value)
    {
        Value = value;
    }

    public static LessonDayOfWeek Monday => new("пн");
    public static LessonDayOfWeek Tuesday => new("вт");
    public static LessonDayOfWeek Wednesday => new("ср");
    public static LessonDayOfWeek Thursday => new("чт");
    public static LessonDayOfWeek Friday => new("пт");
    public static LessonDayOfWeek Saturday => new("сб");
    public static LessonDayOfWeek Sunday => new("вс");

    public string Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
