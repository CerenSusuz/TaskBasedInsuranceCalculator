using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator.Domain;

namespace TaskBasedInsuranceCalculator.Services
{
    public class CalculatorFactory : ICalculatorFactory
    {
        private readonly ICurrencyService currencyService;
        private readonly ITripRepository tripRepository;

        public CalculatorFactory(ICurrencyService currencyService, ITripRepository tripRepository)
        {
            this.currencyService = currencyService;
            this.tripRepository = tripRepository;
        }

        public ICalculator CreateCalculator()
        {
            return new InsurancePaymentCalculator(currencyService, tripRepository);
        }

        public ICalculator CreateCachedCalculator()
        {
            var baseCalculator = new InsurancePaymentCalculator(currencyService, tripRepository);

            return new CachedInsurancePaymentCalculator(baseCalculator);
        }
    }
}
