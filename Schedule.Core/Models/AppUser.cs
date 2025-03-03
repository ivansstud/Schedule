using CSharpFunctionalExtensions;
using Schedule.Core.ValueObjects;
using System.Text.Json.Serialization;

namespace Schedule.Core.Models;

public class AppUser : Entity
{
    private readonly List<Group> _groups = [];
    private readonly List<Group> _createdGroups = [];

    private AppUser(long telegramId, UserName name)
    {
        TelegramId = telegramId;
        Name = name;
    }

    //Для EF Core
    private AppUser() { }

    public long TelegramId { get; private set; }
    public UserName Name { get; private set; }

    [JsonIgnore]
    public IReadOnlyList<Group> Groups => _groups;
    [JsonIgnore]
    public IReadOnlyList<Group> CreatedGroups => _createdGroups;

    public static Result<AppUser> Create(long telegramId, UserName name)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(telegramId, nameof(telegramId));

        var newUser = new AppUser(telegramId, name);
        return Result.Success(newUser);
    }
}
