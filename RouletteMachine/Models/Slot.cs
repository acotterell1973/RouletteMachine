using System;

namespace RouletteMachine
{
    public struct Slot
    {
        public string SlotNumber { get; set; }
        public ConsoleColor SlotColor { get; set; }
        public OddEven OddOrEvent { get; set; }

        public override string ToString()
        {
            return $"[Slot::{SlotNumber} - Color::{SlotColor} - OddOrEven::{OddOrEvent}]";
        }
    }

}
