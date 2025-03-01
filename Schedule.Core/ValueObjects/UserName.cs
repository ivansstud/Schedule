using CSharpFunctionalExtensions;

namespace Schedule.Core.ValueObjects;

public class UserName : ValueObject
{
    public const int MaxLength = 30;

    private UserName(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }

    public string FirstName { get; private set; }
    public string SecondName { get; private set; }
    public string FullName => $"{FirstName} {SecondName}";

    public static Result<UserName> Create(string? firstName, string? secondName)
    {
        if (firstName == null)
        {
            firstName = "";
        }
        if (secondName == null)
        {
            secondName = "";
        }
        if (firstName.Length > MaxLength || secondName.Length > MaxLength)
        {
            Result.Failure<UserName>($"Имя или фамилия не могут быть больше {MaxLength} символов");
        }

        return Result.Success(new UserName(firstName, secondName));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return SecondName;
    }
}
