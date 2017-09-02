using System;

namespace FuckStatistic.Model
{
    internal class SlotIsAlreadyOpenedException : Exception
    {
        public SlotIsAlreadyOpenedException()
        {
        }

        public SlotIsAlreadyOpenedException(string message) : base(message)
        {
        }

        public SlotIsAlreadyOpenedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}