using AutoMapper;
using Domain.Entities;
using Application.Models;
using Infrastructure;
using Application;
using Application.Products;
using Domain.Exceptions;
using System.Data;

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
            var userId = (int)_userContextService.GetUserId;
            list.CreatorId = userId;
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            var condition = _dbContext.ShoppingLists.Where(x => x.Name == dto.Name & x.CreatorId == userId);
            if(condition != null)
            {
                throw new DuplicateObjectNameException(dto.Name);
            }


            user.ShoppingLists.Add(new UserShoppingList
            {
                User = user,
                UserId = user.Id,
                ShoppingList = list,
                ShoppingListId = list.Id
            });

            _dbContext.ShoppingLists.Add(list);

            _dbContext.SaveChanges();

            return list.Id;

        }

        public void DeleteList(int id)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
            if (list == null)
            {
                throw new ListNotFoundException(id);
            }

            _dbContext.ShoppingLists.Remove(list);

            _dbContext.SaveChanges();
        }

        public void AddItemToList(ItemDto dto, int listId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if (list == null)
            {
                throw new ListNotFoundException(listId);
            }

            var item = _mapper.Map<Item>(dto);

            var product = _dbContext.Products.FirstOrDefault(x => x.Name.ToLower() == dto.Name.ToLower());
            if(product == null)
            {
                product = new Product
                {
                    Name = dto.Name
                };
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }

            item.ProductId = product.Id;

            list.Items.Add(item);

            _dbContext.SaveChanges();

        }

        public void DeleteItem(int productId, int listId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if (list == null)
            {
                throw new ListNotFoundException(listId);
            }

            var item = list.Items.FirstOrDefault(x => x.Id == productId);
            if (item == null)
            {
                throw new ItemNotFoundException(productId);
            }

            list.Items.Remove(item);
        }

        public ShoppingListDto GetListById(int id)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == id);
            if (list == null)
            {
                throw new ListNotFoundException(id);
            }

            var result = _mapper.Map<ShoppingListDto>(list);
            return result;
        }

        public void ShareList(int listId, int userId)
        {
            var list = _dbContext.ShoppingLists.FirstOrDefault(x => x.Id == listId);
            if (list == null)
            {
                throw new ListNotFoundException(listId);
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            //user.ShoppingLists.Add(list);
            //list.Users.Add(user);

            _dbContext.SaveChanges();
        }

    }
}
