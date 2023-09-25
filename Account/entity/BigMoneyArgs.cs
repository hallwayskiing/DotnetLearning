using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.entity
{
    internal class BigMoneyArgs:EventArgs
    {
        public Account Account { get; set; }
        public double Money {  get; set; }
        public BigMoneyArgs(Account account,double money) 
        {
            Account = account;
            Money = money;
        }
    }
}
