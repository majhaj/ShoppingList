using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ListNotFoundException : Exception
    {
        public ListNotFoundException(int listId) 
            : base($"List with id {listId} doesn't exist.")
        {

        }
    }
}
