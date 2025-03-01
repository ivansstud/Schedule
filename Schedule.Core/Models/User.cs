using CSharpFunctionalExtensions;
using Schedule.Core.ValueObjects;

namespace Schedule.Core.Models;

public class User : Entity
{
    private readonly List<Group> _groups = [];

    public User(long telegramId, UserName name)
    {
        TelegramId = telegramId;
        Name = name;
    }

    public long TelegramId { get; private set; }
    public UserName Name { get; private set; }
    public IReadOnlyList<Group> Groups  => _groups;

    public static Result<User> Create(long telegramId, UserName name)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(telegramId, nameof(telegramId));

        var newUser = new User(telegramId, name);
        return Result.Success(newUser);
    }
}
