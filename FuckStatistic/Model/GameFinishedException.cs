using System;

namespace FuckStatistic.Model
{
    internal class GameFinishedException : Exception
    {
        public GameFinishedException()
        {
        }

        public GameFinishedException(string message) : base(message)
        {
        }

        public GameFinishedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}