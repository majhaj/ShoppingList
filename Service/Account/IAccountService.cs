using Domain.Models;

namespace Application.Account
{
    public interface IAccountService
    {
        UserDto GetUserById(int id);
        int CreateUser(UserDto dto);
        void DeleteUser(int id);
        void UpdateUser(int id, UserDto dto);
    }
}
