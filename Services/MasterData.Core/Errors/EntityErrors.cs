using MasterData.Core.Shared;

namespace MasterData.Core.Errors;

public static class EntityErrors
{
    public static class Employee
    {
        public static readonly Error EmailAlreadyInUse = new(
            "Member.EmailAlreadyInUse",
            "The specified email is already in use");

        public static readonly Func<Guid, Error> NotFound = id => new Error(
            "Member.NotFound",
            $"The member with the identifier {id} was not found.");

        public static readonly Error InvalidCredentials = new(
            "Member.InvalidCredentials",
            "The provided credentials are invalid");
    }
}
