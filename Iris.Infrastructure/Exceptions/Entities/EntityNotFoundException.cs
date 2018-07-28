using System;

namespace Iris.Infrastructure.Exceptions.Entities
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}
