using System;
namespace FuckStatistic.Model
{
    public class Game
    {
        private int _lifes = 2;

        public Game()
        {
            Map = new Map();
        }

        public Map Map { get; set; }
        public bool ChangeHand { get; set; }

        public Map StartGame() {
            
            while(_lifes > 0)
            {
                int position = RandomHelper.Randomizer.Next(0, Map.Slots.Length);
            }

            return Map;
        }
    }
}