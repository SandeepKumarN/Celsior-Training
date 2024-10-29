using System;

namespace EFAPIProj.Exceptions
{
    public class CollectionEmptyException : Exception
    {
        public CollectionEmptyException() : base("The collection is empty.")
        {
        }

        public CollectionEmptyException(string message) : base(message)
        {
        }
    }
}
