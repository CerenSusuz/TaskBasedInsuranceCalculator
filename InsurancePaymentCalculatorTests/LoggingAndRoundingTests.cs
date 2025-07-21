using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBasedInsuranceCalculator;
using TaskBasedInsuranceCalculator.Services;

namespace InsurancePaymentCalculatorTests
{
    public class LoggingAndRoundingTests
    {
        [Fact]
        public void LoggingCalculator_ShouldLogStartAndEnd()
        {
            // Arrange
            var mockCurrencyService = new MockCurrencyService();
            var mockTripRepository = new MockTripRepository();
            var mockLogger = new MockLogger();
            var baseCalculator = new InsurancePaymentCalculator(mockCurrencyService, mockTripRepository);
            var loggingCalculator = new LoggingCalculator(baseCalculator, mockLogger);

            // Act
            loggingCalculator.CalculatePayment("John Doe");

            // Assert
            var logs = mockLogger.GetLogs();
            Assert.Contains("Start", logs);
            Assert.Contains("End", logs);
        }

        [Fact]
        public void RoundingCalculator_ShouldRoundToNearestWholeNumber()
        {
            // Arrange
            var mockCurrencyService = new MockCurrencyService();
            var mockTripRepository = new MockTripRepository();
            var baseCalculator = new InsurancePaymentCalculator(mockCurrencyService, mockTripRepository);
            var roundingCalculator = new RoundingCalculator(baseCalculator);

            // Act
            decimal roundedPayment = roundingCalculator.CalculatePayment("John Doe");

            // Assert
            Assert.Equal(Math.Round(roundedPayment), roundedPayment);
        }
    }
}
