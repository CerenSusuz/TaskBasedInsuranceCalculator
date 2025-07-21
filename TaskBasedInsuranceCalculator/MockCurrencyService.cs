using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator.Domain;

namespace TaskBasedInsuranceCalculator
{
    public class MockCurrencyService : ICurrencyService
    {
        public decimal LoadCurrencyRate()
        {
            return 1.2m;
        }
    }
}
