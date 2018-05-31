using MoneyExchange.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace money_exchange_backend.Tests
{
    public class TestExchangeDbSet: TestDbSet<Exchange>
    {
        public override Exchange Find(params object[] keyValues)
        {
            return this.SingleOrDefault(c => c.Id == (int)keyValues.Single());
        }
    }
}
