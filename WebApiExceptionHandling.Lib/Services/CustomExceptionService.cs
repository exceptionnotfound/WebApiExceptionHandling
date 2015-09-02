using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExceptionHandling.Lib.Exceptions;

namespace WebApiExceptionHandling.Lib.Services
{
    public class CustomExceptionService
    {
        public void ThrowItemNotFoundException()
        {
            throw new ItemNotFoundException("This is a custom exception.");
        }

        public void ThrowArgumentNullException()
        {
            throw new ArgumentNullException("This is an ArgumentNullException.");
        }

        public void ThrowInvalidOperationException()
        {
            throw new InvalidOperationException("This is an InvalidOperationException.");
        }
    }
}
