using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp.entity
{
    internal class MoneyNotEnoughException:Exception
    {
        public MoneyNotEnoughException() : base("余额不足") { }
    }
}
