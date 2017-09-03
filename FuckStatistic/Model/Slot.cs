using System;
namespace FuckStatistic.Model
{
    public struct Slot
    {
        public byte Position { get; set; }
        public byte PickOrder { get; set; }
        public bool IsPicked { get; set; }
        public bool HasPrize { get; set; }
    }
}