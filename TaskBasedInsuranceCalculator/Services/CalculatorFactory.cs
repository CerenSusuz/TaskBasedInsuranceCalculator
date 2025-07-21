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
        private readonly ILogger logger;

        public CalculatorFactory(ICurrencyService currencyService, ITripRepository tripRepository, ILogger logger)
        {
            this.currencyService = currencyService;
            this.tripRepository = tripRepository;
            this.logger = logger;
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

        public ICalculator CreateLoggingCalculator()
        {
            var baseCalculator = CreateCalculator();

            return new LoggingCalculator(baseCalculator, logger);
        }

        public ICalculator CreateRoundingCalculator()
        {
            var baseCalculator = CreateCalculator();

            return new RoundingCalculator(baseCalculator);
        }
    }
}
