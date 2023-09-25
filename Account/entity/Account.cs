using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.entity
{
    internal class Account
    {
        private int id;
        public int Id {  get { return id; } private set { id = value; } }

        private double money;
        public double Money { get {  return money; } private set { money = value; } }

        public Account(int id)
        {
            Id = id;
            Money = 0;
        }

        virtual public void SaveMoney(double money)
        {
            Money += money;
        }
        virtual public void FetchMoney(double money)
        {
            if(money>Money)
                throw new MoneyNotEnoughException();

            Money -= money;
        }

        public delegate void BigMoneyHandler(BigMoneyArgs e);

        public event BigMoneyHandler BigMoneyFetched;

        virtual public void OnBigMoneyFetching(BigMoneyArgs e)
        {
            BigMoneyFetched(e);
        }
    }
}
