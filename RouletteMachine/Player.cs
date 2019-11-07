using System;
using System.Collections.Generic;
using System.Text;

namespace RouletteMachine
{
    internal class Player
    {
        private double _bankAccountFunds;

        internal void FundAccount(double amount)
        {
            _bankAccountFunds = amount;
        }

        internal void AddToAccount(double earnings)
        {
            _bankAccountFunds += earnings;
        }
        internal void TakeFromAccount(double loses)
        {
            _bankAccountFunds -= loses;
        }

        internal bool IsfundsAvailable(double amount)
        {
            return (_bankAccountFunds > amount) ? true : false; 
        }

        internal double GetBalance()
        {
           return _bankAccountFunds;
        }
    }
}
