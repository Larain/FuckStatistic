using System;
using System.Threading;

namespace FuckStatistic
{
    public static class RandomHelper
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Rand(int max)
        {
            return random.Value.Next(max);
        }
    }
}