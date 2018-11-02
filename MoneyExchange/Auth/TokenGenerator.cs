using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace money_exchange_backend.Auth
{
    public static class TokenGenerator
    {
        public static async Task<string> Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}