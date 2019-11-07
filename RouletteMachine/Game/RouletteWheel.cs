using System;
using System.Collections.Generic;

namespace RouletteMachine
{

    internal class RouletteWheel
    {
        readonly SortedList<int, Slot> _wheelSlots;
        readonly Random _rnd;
       
        public RouletteWheel()
        {
    
            _wheelSlots = new SortedList<int, Slot>();
            _rnd = new Random();

            InitializeWheel();
        }

        private void InitializeWheel()
        {
            _wheelSlots.Add(-1, new Slot()
            {
                SlotColor = ConsoleColor.Green,
                SlotNumber = "0",
                OddOrEvent = OddEven.None
            });

            _wheelSlots.Add(0, new Slot()
            {
                SlotColor = ConsoleColor.Green,
                SlotNumber = "00",
                OddOrEvent = OddEven.None
            });

            for (int slotCount = 1; slotCount < 36; slotCount++)
            {
                var isEven = (slotCount % 2 == 0);
                _wheelSlots.Add(slotCount, new Slot()
                {
                    SlotColor = isEven ? ConsoleColor.Red : ConsoleColor.Black,
                    OddOrEvent = isEven ? OddEven.Even : OddEven.Odd,
                    SlotNumber = $"{slotCount}"
                }); ;
            }
        }
        public Slot Spin()
        {
            var getSlot = _rnd.Next(-1, 36);
            return _wheelSlots[getSlot];
            
        }


    }
}
