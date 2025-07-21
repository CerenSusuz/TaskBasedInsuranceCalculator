using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedInsuranceCalculator.Services
{
    public class CachedInsurancePaymentCalculator : ICalculator
    {
        private readonly ICalculator baseCalculator;
        private readonly Dictionary<string, decimal> cache;

        public CachedInsurancePaymentCalculator(ICalculator baseCalculator)
        {
            this.baseCalculator = baseCalculator;
            this.cache = new Dictionary<string, decimal>();
        }

        public decimal CalculatePayment(string touristName)
        {
            if (cache.ContainsKey(touristName))
            {
                return cache[touristName];
            }

            decimal payment = baseCalculator.CalculatePayment(touristName);

            cache[touristName] = payment;

            return payment;
        }
    }
}
