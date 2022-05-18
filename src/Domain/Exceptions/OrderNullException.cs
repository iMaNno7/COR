using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COR.Domain.Exceptions
{
    public class OrderNullException : ArgumentNullException
    {
        public OrderNullException()
            : base($"order is invalid.")
        {
        }
    }
}
