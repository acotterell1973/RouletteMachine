using System;

namespace RouletteMachine
{
    public class RulesEngine
    {
        double _betAmount;
        public RulesEngine()
        {

        }
        public RulesEngine(double betAmount)
        {
            _betAmount = betAmount;
        }
        public double BetAmount { get { return _betAmount; } set { _betAmount = value; } }

        internal Payout DeterminePayoutForEvenOdd(Slot slot, OddEven betchoice)
        {
            if (slot.OddOrEvent == betchoice)
            {
                return new Payout { PayOff = 1, Amount = _betAmount * 2 };
            }

            return new Payout { PayOff = 0, Amount = 0 };
        }
        internal Payout DeterminePayoutForColor(Slot slot, ConsoleColor betchoice)
        {

            if (slot.SlotColor == betchoice)
            {
                return new Payout { PayOff = 1, Amount = _betAmount * 2 }; // 1 to 1 ratio
            }

            return new Payout { PayOff = 0, Amount = 0 };
        }
        internal Payout DeterminePayoutForSingleNumber(Slot slot, int betchoice)
        {

            int.TryParse(slot.SlotNumber, out int slotNumber);
            if (betchoice == -1 && slot.SlotNumber == "00") { return new Payout { PayOff = 35, Amount = _betAmount * 35 }; }

            if (slotNumber == betchoice) { return new Payout { PayOff = 35, Amount = _betAmount * 35 }; }

            return new Payout { Amount = 0 };
        }

        internal Payout DeterminePayoutForFirst12(Slot slot, SlotRange betchoice)
        {
            int.TryParse(slot.SlotNumber, out int slotNumber);

            switch (slotNumber)
            {
                case int n when ((n >= 1 && n <= 12) && betchoice == SlotRange.First):
                    return new Payout { PayOff = 2, Amount = (_betAmount * 2) + _betAmount };

                case int n when ((n >= 13 && n <= 24) && betchoice == SlotRange.Second):
                    return new Payout { PayOff = 2, Amount = (_betAmount * 2) + _betAmount };

                case int n when ((n >= 25 && n <= 36) && betchoice == SlotRange.Third):
                    return new Payout { PayOff = 2, Amount = (_betAmount * 2) + _betAmount };
                default:
                    return new Payout { Amount = 0 };
            }

            
        }

        internal Payout DeterminePayoutForLowHigh(Slot slot, HighLow betchoice)
        {
            int.TryParse(slot.SlotNumber, out int slotNumber);

            switch (slotNumber)
            {
                case int n when ((n >= 1 && n <= 18) && betchoice == HighLow.Low):
                    return new Payout { PayOff = 2, Amount = _betAmount * 2 };

                case int n when ((n >= 19 && n <= 36) && betchoice == HighLow.High):
                    return new Payout { PayOff = 2, Amount = _betAmount * 2 };
                default:
                    return new Payout { Amount = 0 };
            }

        }


    }
}
