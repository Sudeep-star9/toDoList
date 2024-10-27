using toDoList.Dtos.UserDtos;

namespace toDoList.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(ApplicationUser user, List<string> roles);
    }
}
