using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class LessonTime : ValueObject
{
    private LessonTime(TimeOnly startTime, TimeOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }

    public static Result<LessonTime> Create(TimeOnly startTime, TimeOnly endTime)
    {
        if (endTime <= startTime)
        {
            return Result.Failure<LessonTime>("Дата окончания занятия не может быть раньше или равной дате начала");
        }

        return Result.Success(new LessonTime(startTime, endTime));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return StartTime;
        yield return EndTime;
    }
}
