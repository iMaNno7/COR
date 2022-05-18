using COR.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COR.Domain.Validation
{
    public static class CheckValidity
    {
        public delegate void CheckValidate(Order order);

        public static void CheckValidityOrder(this Order order, CheckValidate validateMehtod)
        {
            try
            {
                validateMehtod(order);
            }
            catch (OrderNullException ex)
            {
                // todo: add method 
                throw ex;
            }
            catch (InvalidPriceException ex)
            {
                // todo: add method 
                throw ex;
            }
            finally
            {
                // todo: add method 
            }
        }
    }
}
