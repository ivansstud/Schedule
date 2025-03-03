using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class LessonDayOfWeek : ValueObject
{
    private static readonly List<LessonDayOfWeek> _days = [Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday];

    private LessonDayOfWeek(string value)
    {
        Value = value;
    }

    public static LessonDayOfWeek Monday => new(nameof(Monday));
    public static LessonDayOfWeek Tuesday => new(nameof(Tuesday));
	public static LessonDayOfWeek Wednesday => new(nameof(Wednesday));
	public static LessonDayOfWeek Thursday => new(nameof(Thursday));
	public static LessonDayOfWeek Friday => new(nameof(Friday));
	public static LessonDayOfWeek Saturday => new(nameof(Saturday));
	public static LessonDayOfWeek Sunday => new(nameof(Sunday));

	public string Value { get; private set; }

    public static Result<LessonDayOfWeek> Create(string value)
    {
        var newDay = new LessonDayOfWeek(value);

        if (_days.Any(x => x.Value == newDay.Value) == false)
        {
            return Result.Failure<LessonDayOfWeek>("Неверный формат");
        }

        return Result.Success(newDay);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
