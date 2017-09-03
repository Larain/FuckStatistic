using System;
using FuckStatistic.Model;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FuckStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            var t1 = Task<string>.Factory.StartNew(() => ConductExperiment(1000000, true));
            var t2 = Task<string>.Factory.StartNew(() => ConductExperiment(1000000, false));

            t1.ContinueWith((o) => Console.WriteLine(t1.Result));
            t2.ContinueWith((o) => Console.WriteLine(t2.Result));

            //Console.WriteLine(ConductExperiment(1000000, true));
            //Console.WriteLine(ConductExperiment(1000000, false));

            Task.WaitAll(new[] { t1, t2 });
        }

        public static string ConductExperiment(int times, bool toChangeOrNotToChange)
        {
            Game[] games = new Game[times];

            for (int i = 0; i < games.Length; i++)
            {
                var game = new Game()
                {
                    ChangeChoice = toChangeOrNotToChange
                };
                game.StartGame();

                games[i] = game;
            }

            int won = games.Count(x => x.Result != null && x.Result.Value);
            int lose = games.Count(x => x.Result != null && !x.Result.Value);

            string result = $"Computer changed choice = {toChangeOrNotToChange}";
            result += "\n";
            result += $"won: {won} times ({(won * 100 * 1.00 / times * 1.00).ToString("F")}%); ";
            result += $"lose: {lose} times ({(lose * 100 * 1.00 / times * 1.00).ToString("F")}%)";

            return result;
        }
    }
}