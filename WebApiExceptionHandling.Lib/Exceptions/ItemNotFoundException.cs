using System;

namespace WebApiExceptionHandling.Lib.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string message) : base(message) { }

        public ItemNotFoundException(string message, Exception ex) : base(message, ex) { }
    }
}
