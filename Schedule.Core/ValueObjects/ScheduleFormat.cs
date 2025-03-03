using CSharpFunctionalExtensions;
using System;

namespace Schedule.Core.ValueObjects;

public class ScheduleFormat : ValueObject
{
    private static readonly List<ScheduleFormat> _formates = [Cyclic, Permanent];

    private ScheduleFormat(string value)
    {
        Value = value;
    }

    public static ScheduleFormat Cyclic => new("Цикличное");
    public static ScheduleFormat Permanent => new("Постоянное");

    public string Value { get; private set; }

    public static Result<ScheduleFormat> Create(string value)
    {

        var newFormat = new ScheduleFormat(value);

        if (_formates.Any(x => x.Value == newFormat.Value) == false)
        {
            return Result.Failure<ScheduleFormat>("Неверный формат");
        }

        return Result.Success(newFormat)!;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
