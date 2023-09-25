using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.entity
{
    internal class CreditAccount:Account
    {
        public readonly double OriginCredit;

        private double credit;
        public double Credit {  get { return credit; } private set {  credit = value; } }

        public CreditAccount(int id,double credit) : base(id)
        {
            OriginCredit = credit;
            Credit = credit;
        }

        override public void FetchMoney(double money)
        {
            if (money >= 10000)
            {
                OnBigMoneyFetching(new BigMoneyArgs(this, money));
            }
            if(Credit+Money<money)
                throw new MoneyNotEnoughException();

            if (Money < money)
            {
                Credit -= (money - Money);
                base.FetchMoney(Money);
            }
            else
            {
                base.FetchMoney(money);
            }
        }

        public override void SaveMoney(double money)
        {
            double needToReturn = OriginCredit - Credit;
            if (needToReturn > 0)
            {
                if (money < needToReturn)
                {
                    Credit += money;
                }
                else
                {
                    base.SaveMoney(money-needToReturn);
                    Credit = OriginCredit;                   
                }
            }
            else
            {
                base.SaveMoney(money);
            }
        }
    }
}
