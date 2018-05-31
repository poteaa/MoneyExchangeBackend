using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExchange.Data
{
    public interface IMoneyExchangeContext: IDisposable
    {
        DbSet<Currency> Currencies { get; set; }
        DbSet<Exchange> Exchanges { get; set; }
        DbSet<User> Users { get; set; }
    }   
}
