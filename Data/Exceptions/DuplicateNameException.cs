using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DuplicateObjectNameException : Exception
    {
        public DuplicateObjectNameException(string name) 
            : base($"Object with a name {name} already exists.")
        {

        }
    }
}
