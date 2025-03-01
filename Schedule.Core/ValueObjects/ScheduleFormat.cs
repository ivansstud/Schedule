using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class ScheduleFormat : ValueObject
{
    private ScheduleFormat(string value)
    {
        Value = value;
    }

    public static ScheduleFormat Cyclic => new("Цикличное");
    public static ScheduleFormat Permanent => new("Постоянное");

    public string Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
