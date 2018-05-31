using MoneyExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace money_exchange_backend.Tests
{
    public class TestCurrencyDbSet: TestDbSet<Currency>
    {
        public override Currency Find(params object[] keyValues)
        {
            return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
        }
    }
}
