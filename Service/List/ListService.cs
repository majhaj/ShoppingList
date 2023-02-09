using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Infrastructure;
using Application;
using Application.Products;
using Domain.Exceptions;

namespace Application.List
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

        public int CreateList(CreateListDto dto)
        {
            var list = _mapper.Map<ShoppingList>(dto);
            //var userId = _userContextService.GetUserId;
            //list.CreatorId = (int)userId;
            //var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            //list.Users.Add(user);

            _dbContext.ShoppingLists.Add(list);

            _dbContext.SaveChanges();

            return list.Id;

        }

        public void DeleteList(int id)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
            if (list == null)
            {
                throw new NotFoundException($"List with id {id} doesn't exist.");
            }

            _dbContext.ShoppingLists.Remove(list);

            _dbContext.SaveChanges();
        }

        public void AddItemToList(ItemDto dto, int listId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if (list == null)
            {
                throw new NotFoundException($"List with id {listId} doesn't exist.");
            }

            var product = _dbContext.Products.FirstOrDefault(x => x.Name.ToLower() == dto.Name.ToLower());
            if(product == null)
            {
                product = new Product
                {
                    Name = dto.Name
                };
                _dbContext.Products.Add(product);
            }


            var item = _mapper.Map<Item>(dto);

            item.ProductId = product.Id;

            list.Items.Add(item);

            _dbContext.SaveChanges();

        }

        public void DeleteItem(int productId, int listId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if (list == null)
            {
                throw new NotFoundException($"List with id {listId} doesn't exist.");
            }

            var item = list.Items.FirstOrDefault(x => x.Id == productId);
            if (item == null)
            {
                throw new NotFoundException($"Product with id {productId} is not on the list with id {listId}.");
            }

            list.Items.Remove(item);
        }

        public ShoppingListDto GetListById(int id)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
            if (list == null)
            {
                throw new NotFoundException($"List with id {id} doesn't exist.");
            }

            var result = _mapper.Map<ShoppingListDto>(list);
            return result;
        }

        public void ShareList(int listId, int userId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if (list == null)
            {
                throw new NotFoundException($"List with id {listId} doesn't exist.");
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new NotFoundException($"User with id {userId} doesn't exist.");
            }

            user.ShoppingLists.Add(new UserShoppingList
            {
                User= user,
                UserId= userId,
                ShoppingList = list,
                ShoppingListId = listId

            });

            _dbContext.SaveChanges();
        }

    }
}
