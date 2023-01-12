using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        UserDto GetUserById(int id);
        int CreateUser(UserDto dto);
        void DeleteUser(int id);
        void UpdateUser(int id, UserDto dto);
    }
}
