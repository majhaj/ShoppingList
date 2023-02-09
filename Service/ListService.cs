using AutoMapper;
using Data.Entities;
using Data.Models;
using Repository;

namespace Service
{
    public class ListService : IListService
    {
        private readonly ShoppingListDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;

        public ListService(ShoppingListDbContext dbContext, IMapper mapper, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userContextService = userContextService;
        }

        public int Create(CreateListDto dto)
        {
            var list = _mapper.Map<ShoppingList>(dto);
            var userId = _userContextService.GetUserId;
            list.CreatorId = (int)userId;
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            
            list.Users.Add(user);

            user.ShoppingLists.Add(list);

            _dbContext.ShoppingLists.Add(list);

            _dbContext.SaveChanges();

            return list.Id;
            
        }

        public void Delete(int id)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
            if(list == null)
            {
                throw new Exception($"List with id {id} doesn't exist.");
            }

            var userId = list.CreatorId;
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            user.ShoppingLists.Remove(list);

            _dbContext.ShoppingLists.Remove(list);

            _dbContext.SaveChanges();
        }

        public void AddProductToList(ProductDto dto, int listId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if(list == null)
            {
                throw new Exception($"List with id {listId} doesn't exist.");
            }

            var product = _mapper.Map<Product>(dto);

            list.Products.Add(product);
            
            _dbContext.SaveChanges();

        }

        public void DeleteProduct(int productId, int listId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if(list ==null)
            {
                throw new Exception($"List with id {listId} doesn't exist.");
            }

            var item = list.Products.FirstOrDefault(x => x.Id == productId);
            if(item == null)
            {
                throw new Exception($"Product with id {productId} is not on the list with id {listId}.");
            }

            list.Products.Remove(item);
        }

        public ShoppingListDto GetById(int id)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
            if(list == null)
            {
                throw new Exception($"List with id {id} doesn't exist.");
            }

            var result = _mapper.Map<ShoppingListDto>(list);
            return result;
        }

        public void ShareList(int listId, int userId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x =>x.Id == listId);
            if(list == null)
            {
                throw new Exception($"List with id {listId} doesn't exist.");
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if(user == null)
            {
                throw new Exception($"User with id {userId} doesn't exist.");
            }

            user.ShoppingLists.Add(list);

            _dbContext.SaveChanges();
        }
    }
}
