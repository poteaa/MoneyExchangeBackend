using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExchange.Model
{
    public class ConversionDTO
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
