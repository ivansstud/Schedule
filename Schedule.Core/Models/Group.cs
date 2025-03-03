using CSharpFunctionalExtensions;
using Schedule.Core.ValueObjects;
using System.Text.Json.Serialization;

namespace Schedule.Core.Models;

public class Group : Entity
{
    public const int MaxNameLength = 50;
    public const int MaxInstitutionNameLength = 100;
    public const int MaxDescriptionLength = 100;

    private readonly List<AppUser> _members = [];
    private readonly List<Lesson> _lessons = [];

    private Group(string name, long creatorId, ScheduleFormat scheduleFormat, string? institutionName, string? description)
    {
        Name = name;
        CreatorId = creatorId;
        ScheduleFormat = scheduleFormat;
        InstitutionName = institutionName;
        Description = description;
    }

    //Для EF Core
    private Group(){ }

    public string Name { get; private set; }
    public long CreatorId { get; private set; }
    public ScheduleFormat ScheduleFormat { get; private set; }

    [JsonIgnore]
    public AppUser Creator { get; private set; } = null!;

    [JsonIgnore]
    public IReadOnlyList<AppUser> Members => _members;

    [JsonIgnore]
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
