using System;
namespace FuckStatistic.Model
{
    public class Map
    {
        private int _pickOrderCounter;

        public Map()
        {
            Slots = new Slot[3];
        }

        public Slot[] Slots { get; private set; }

        public void PlacePrize() {
            int index = RandomHelper.Randomizer.Next(0, 2);
            Slots[index].HasPrize = true;
        }

        public bool OpenSlot(int position) {
            if (Slots[position].IsPicked) throw new SlotIsAlreadyOpenedException();

            Slots[position].IsPicked = true;
            Slots[position].PickOrder = _pickOrderCounter++;

            return Slots[position].HasPrize;
        }
    }
}
