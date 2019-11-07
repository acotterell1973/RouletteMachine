using System;
using System.Collections.Generic;
using System.Text;

namespace RouletteMachine
{
    public class Bookie
    {
        double _betAmount;
        BetType _betType;
        string _betChoice;
        int _numericChoice = -1;
        ConsoleColor _colorChoice;
        OddEven _oddEven;
        HighLow _highLow;
        SlotRange _slotRange;
        readonly RulesEngine _rulesEngine;
        public Bookie()
        {
            _rulesEngine = new RulesEngine();
        }
        public double BetAmount { get => _betAmount; set => _betAmount = value; }

        public bool PlaceBet(double betAmount)
        {
            BetAmount = betAmount;
            return TakeBet();
        }
        public Payout GetPayout(Slot landedSlot)
        {
            _rulesEngine.BetAmount = BetAmount;

            switch (_betType)
            {
                case BetType.bet_on_single_digit:
                    return _rulesEngine.DeterminePayoutForSingleNumber(landedSlot, _numericChoice);

                case BetType.bet_on_red_or_black:
                    return _rulesEngine.DeterminePayoutForColor(landedSlot, _colorChoice);

                case BetType.bet_on_1st_12_2nd_12_3rd_12:
                    return _rulesEngine.DeterminePayoutForFirst12(landedSlot, _slotRange);

                case BetType.bet_on_high_low:
                    return _rulesEngine.DeterminePayoutForLowHigh(landedSlot, _highLow);

                case BetType.bet_on_odd_even:
                    return _rulesEngine.DeterminePayoutForEvenOdd(landedSlot, _oddEven);

            }

            return new Payout();

        }
        private bool TakeBet()
        {
            Console.WriteLine("What bet would you like to make?");
            Console.WriteLine("1 - bet on red or black ?");
            Console.WriteLine("2 - bet on 1st 12 (1-12), 2nd 12 (13-24), 3rd 12 (25-36)?");
            Console.WriteLine("3 - bet on a specific number?");
            Console.WriteLine("4 - bet on high/low?");
            Console.WriteLine("5 - bet on odd or even?");
            Console.WriteLine("6 - quit");

            int.TryParse(Console.ReadLine(), out int bet);
            switch (bet)
            {
                case 1:
                    BetOnColor();
                    break;

                case 2:
                    BetOnFirstTweleve();
                    break;
                case 3:
                    BetOnNumber();
                    break;
                case 4:
                    BetOnHighLow();
                    break;
                case 5:
                    BetOnOddOrEven();
                    break;
                default:
                    return false;

            }
            return true;
        }

        private void BetOnColor()
        {
            Console.WriteLine("Which color, Red or Black?");
            _betType = BetType.bet_on_red_or_black;

            _betChoice = Console.ReadLine();
            _colorChoice = _betChoice.ToLower() == "red" ? ConsoleColor.Red : ConsoleColor.Black;
        }
        private void BetOnOddOrEven()
        {
            Console.WriteLine("Type O for Odd or E for Even?");
            _betType = BetType.bet_on_odd_even;

            _betChoice = Console.ReadLine();
            _oddEven = _betChoice.ToLower() == "e" ? OddEven.Even : OddEven.Odd;
        }

        private void BetOnFirstTweleve()
        {
            Console.WriteLine("Which 12?  1st, 2nd, or 3rd? Type 1, 2 or 3.");
            _betType = BetType.bet_on_1st_12_2nd_12_3rd_12;

            int.TryParse(Console.ReadLine(), out int bet);
            
            switch (bet)
            {
                case 1:
                    _slotRange = SlotRange.First;
                    break;

                case 2:
                    _slotRange = SlotRange.Second;
                    break;

                case 3:
                    _slotRange = SlotRange.Third;
                    break;
            }
        }

        private void BetOnNumber()
        {
            Console.WriteLine("Choose a number.");
            _betType = BetType.bet_on_single_digit;

            var bet = Console.ReadLine();
            if (bet == "00")
                _numericChoice = -1;
            else int.TryParse(bet, out _numericChoice);
        }

        private void BetOnHighLow()
        {
            Console.WriteLine("Type (h) for high or (l) for low.");
            _betType = BetType.bet_on_high_low;

            _betChoice = Console.ReadLine();
            _highLow = _betChoice.ToLower() == "h" ? HighLow.High : HighLow.Low;
        }
    }
}
