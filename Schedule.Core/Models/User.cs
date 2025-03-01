using CSharpFunctionalExtensions;
using Schedule.Core.ValueObjects;

namespace Schedule.Core.Models;

public class User : Entity
{
    private readonly List<Group> _groups = [];
    private readonly List<Group> _createdGroups = [];

    private User(long telegramId, UserName name)
    {
        TelegramId = telegramId;
        Name = name;
    }

    //Для EF Core
    private User() { }

    public long TelegramId { get; private set; }
    public UserName Name { get; private set; }
    public IReadOnlyList<Group> Groups => _groups;
    public IReadOnlyList<Group> CreatedGroups => _createdGroups;

    public static Result<User> Create(long telegramId, UserName name)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(telegramId, nameof(telegramId));

        var newUser = new User(telegramId, name);
        return Result.Success(newUser);
    }
}
