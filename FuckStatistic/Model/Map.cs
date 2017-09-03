using System;
using System.Linq;

namespace FuckStatistic.Model
{
    public class Map
    {
        private byte _pickOrderCounter;

        public Map()
        {
            Slots = new Slot[3];
            _pickOrderCounter = 1;
        }

        public Slot[] Slots { get; private set; }

        /// <summary>
        /// Places the prize randomly.
        /// </summary>
        public void PlacePrize()
        {
            for (byte i = 0; i < Slots.Length; i++)
            {
                Slots[i].Position = i;
            }

            int index = RandomHelper.Rand(Slots.Length);
            Slots[index].HasPrize = true;
        }

        /// <summary>
        /// Choose slot and open it (That action finish the game)
        /// </summary>
        /// <returns><c>true</c>, if slot had prize, <c>false</c> otherwise.</returns>
        /// <param name="position">Position of slot</param>
        public bool OpenSlot(int position)
        {
            if (Slots[position].IsPicked) throw new SlotIsAlreadyOpenedException();
            if (Slots.Any(x => x.IsPicked)) throw new GameFinishedException();


			Slots[position].IsPicked = true;
            Slots[position].PickOrder = _pickOrderCounter++;

            return Slots[position].HasPrize;
        }

        /// <summary>
        /// Remeber that slot choosed was choosed
        /// </summary>
        /// <param name="position">Position of slot</param>
        public void ChooseSlot(int position)
        {
            if (Slots[position].IsPicked) throw new SlotIsAlreadyOpenedException();
            if (Slots[position].PickOrder != 0) throw new SlotIsAlreadyOpenedException();

            Slots[position].PickOrder = _pickOrderCounter++;

        }
    }
}