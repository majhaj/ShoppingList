using AutoMapper;
using Data.Entities;
using Data.Models;
using Repository;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly ShoppingListDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ShoppingListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int CreateUser(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"User with id {id} doesn't exist.");
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public UserDto GetUserById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception($"User with id {id} doesn't exist.");
            }

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public void UpdateUser(int id, UserDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"User with id {id} doesn't exist.");
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Birthday = dto.Birthday;
            user.Email = dto.Email;
            
            _dbContext.SaveChanges();
        }
    }
}
