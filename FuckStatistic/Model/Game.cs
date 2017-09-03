using System;
using System.Linq;
using System.Text;

namespace FuckStatistic.Model
{
    public class Game
    {
        private readonly Map _map;

        public Game()
        {
            _map = new Map();
            _map.PlacePrize();
        }

        public bool ChangeChoice { get; set; }

        public bool? Result
        {
            get
            {
                try
                {
                    return _map.Slots.First(x => x.IsPicked).HasPrize;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        public Map StartGame()
        {
            int firstPosition = RandomHelper.Rand(_map.Slots.Length);
            _map.ChooseSlot(firstPosition);

            // If strategy is to 'chagne choice'
			if (ChangeChoice)
            {
                // Flash bad slot position
                var badSlot = _map.Slots.First(x => !x.HasPrize && x.Position != firstPosition);
                _map.ChooseSlot(badSlot.Position);

                // Select slot that is not equal to the first choice and is not equal to shown bad slot
                var selectedSlot = _map.Slots.First(x => x.Position != firstPosition && x.Position != badSlot.Position);
                _map.OpenSlot(selectedSlot.Position);
            }
            // Otherwise open slot we choosed first time
            else
            {
                _map.OpenSlot(firstPosition);
            }

            return _map;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var slot in _map.Slots)
            {
                sb.AppendLine($"<Slot #{slot.Position}> IsPicked = {slot.IsPicked}; PickOrder = {slot.PickOrder}; HasPrize = {slot.HasPrize}");
            }

            return sb.ToString();
        }
    }
}