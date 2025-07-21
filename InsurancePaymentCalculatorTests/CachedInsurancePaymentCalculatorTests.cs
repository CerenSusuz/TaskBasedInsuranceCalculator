using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator.Services;

namespace InsurancePaymentCalculatorTests
{
    public class CachedInsurancePaymentCalculatorTests
    {
        [Fact]
        public void CalculatePayment_ShouldUseCache_AfterFirstCalculation()
        {
            // Arrange
            var mockCurrencyService = new MockCurrencyService();
            var mockTripRepository = new MockTripRepository();
            var baseCalculator = new InsurancePaymentCalculator(mockCurrencyService, mockTripRepository);
            var cachedCalculator = new CachedInsurancePaymentCalculator(baseCalculator);

            // Act
            decimal firstPayment = cachedCalculator.CalculatePayment("John Doe");

            // Act
            decimal secondPayment = cachedCalculator.CalculatePayment("John Doe");

            // Assert
            Assert.Equal(firstPayment, secondPayment);
        }
    }
}
