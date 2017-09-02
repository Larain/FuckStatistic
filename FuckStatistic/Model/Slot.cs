using System;
namespace FuckStatistic.Model
{
    public struct Slot
    {
        public int PickOrder { get; set; }
        public bool IsPicked { get; set; }
        public bool HasPrize { get; set; }
    }
}