﻿
namespace AceAttitude.Data.Repositories.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message) : base(message)
        {

        }
    }
}