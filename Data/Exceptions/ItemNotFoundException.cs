using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(int id) 
            : base($"Item with id {id} not found.")
        {
        }
    }
}
