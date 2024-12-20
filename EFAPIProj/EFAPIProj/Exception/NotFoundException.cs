﻿using System;

namespace EFAPIProj.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Entity not found.")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
