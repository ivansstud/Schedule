using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class LessonTime : ValueObject
{
    private LessonTime(DateOnly startTime, DateOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public DateOnly StartTime { get; private set; }
    public DateOnly EndTime { get; private set; }

    public static Result<LessonTime> Create(DateOnly startTime, DateOnly endTime)
    {
        if (startTime <= endTime)
        {
            return Result.Failure<LessonTime>("Дата начала занятия не может быть раньше или равной дате окончания");
        }

        return Result.Success(new LessonTime(startTime, endTime));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartTime;
        yield return EndTime;
    }
}
