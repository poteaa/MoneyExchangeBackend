using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExchange.Model
{
    public class ExchangeMin
    {
        public string CurrencyAcronym { get; set; }
        public double Rate { get; set; }

    }
    public class ExchangeDTO : ExchangeMin
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public System.DateTime date { get; set; }
    }
}
