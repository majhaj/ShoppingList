using Application.Models;

namespace Application.Account
{
    public interface IAccountService
    {
        UserDto GetUserById(int id);
        int CreateUser(CreateUserDto dto);
        void DeleteUser(int id);
        void UpdateUser(int id, CreateUserDto dto);
        string GenerateJwtToken(LoginDto dto);
    }
}
