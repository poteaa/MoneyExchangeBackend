using MoneyExchange.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace money_exchange_backend.Tests
{
    public class MoneyExchangeAppContext: IMoneyExchangeContext
    {
        public MoneyExchangeAppContext()
        {
            this.Currencies = new TestCurrencyDbSet();
            this.Exchanges = new TestExchangeDbSet();
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<User> Users { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Currency item) { }
        public void Dispose() { }
    }
}
