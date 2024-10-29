using System;

namespace EFAPIProj.Exceptions
{
    public class CouldNotAddException : Exception
    {
        public CouldNotAddException() : base("Could not add the entity.")
        {
        }

        public CouldNotAddException(string message) : base(message)
        {
        }
    }
}
