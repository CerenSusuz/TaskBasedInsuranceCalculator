using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator;
using TaskBasedInsuranceCalculator.Services;

namespace InsurancePaymentCalculatorTests
{
    public class DynamicCalculatorTests
    {
        [Fact]
        public void Should_UseCacheAndRounding_Dynamically()
        {
            var mockCurrencyService = new MockCurrencyService();
            var mockTripRepository = new MockTripRepository();
            var mockLogger = new MockLogger();

            var factory = new CalculatorFactory(mockCurrencyService, mockTripRepository, mockLogger);

            var calculator = factory.CreateDynamicCalculator(
                calc => new CachedInsurancePaymentCalculator(calc),
                calc => new RoundingCalculator(calc)
            );

            var result1 = calculator.CalculatePayment("John Doe");
            var result2 = calculator.CalculatePayment("John Doe");

            Assert.Equal(result1, result2);
            Assert.Equal(Math.Round(result1), result1);
        }
    }
}
