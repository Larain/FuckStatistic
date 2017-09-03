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

        public bool ChangeChoise { get; set; }

        public bool? Result
        {
            get
            {
                try
                {
                    return _map.Slots.First(x => x.IsPicked).HasPrize;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
        }

        public Map StartGame()
        {
            int firstPosition = RandomHelper.Rand(_map.Slots.Length);
            _map.ChooseSlot(firstPosition);

            var badSlot = _map.Slots.First(x => !x.HasPrize && x.Position != firstPosition);
            _map.ChooseSlot(badSlot.Position);

            // Если меня меняем выбор
            if (ChangeChoise)
            {
                // Тогда выбираем слот которые не равен первому выбору и который нам показали
                var selectedSlot = _map.Slots.First(x => x.Position != firstPosition && x.Position != badSlot.Position);
                _map.OpenSlot(selectedSlot.Position);
            }
            // Иначе просто открываем слот
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