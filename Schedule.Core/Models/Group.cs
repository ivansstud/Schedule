using CSharpFunctionalExtensions;
using Schedule.Core.ValueObjects;

namespace Schedule.Core.Models;

public class Group : Entity
{
    private readonly List<User> _members = [];
    private readonly List<Lesson> _lessons = [];

    private Group(string name, long creatorId, ScheduleFormat scheduleFormat, string? institutionName, string? description)
    {
        Name = name;
        CreatorId = creatorId;
        ScheduleFormat = scheduleFormat;
        InstitutionName = institutionName;
        Description = description;
    }

    public string Name { get; private set; }
    public long CreatorId { get; private set; }
    public User Creator { get; private set; } = null!;
    public ScheduleFormat ScheduleFormat { get; private set; }
    public IReadOnlyList<User> Members => _members;
    public IReadOnlyList<Lesson> Lessons => _lessons;
    public string? InstitutionName { get; private set; }
    public string? Description { get; private set; }

    public static Result<Group> Create(string name, long creatorId, ScheduleFormat scheduleFormat, string? institutionName = null, string? description = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(creatorId, nameof(creatorId));

        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Group>("Имя группы не может быть пустым");
        }
        if (string.IsNullOrEmpty(institutionName) || string.IsNullOrWhiteSpace(institutionName))
        {
            institutionName = null;
        }
        if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
        {
            description = null;
        }

        var newGroup = new Group(name, creatorId, scheduleFormat, institutionName, description);
        return Result.Success(newGroup);
    }
}
