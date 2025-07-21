using TaskBasedInsuranceCalculator;
using TaskBasedInsuranceCalculator.Domain;
using TaskBasedInsuranceCalculator.Services;

namespace InsurancePaymentCalculatorTests
{
    public class InsurancePaymentCalculatorTests
    {
        [Fact]
        public void CalculatePayment_ShouldReturnCorrectPayment()
        {
            // Arrange
            var mockCurrencyService = new MockCurrencyService();
            var mockTripRepository = new MockTripRepository();
            var calculator = new InsurancePaymentCalculator(mockCurrencyService, mockTripRepository);

            // Act
            decimal payment = calculator.CalculatePayment("John Doe");

            // Assert
            decimal expectedPayment =
                Constants.A * 1.2m * 1000m
              + Constants.B * 1.2m * 2000m
              + Constants.C * 1.2m * 500m;

            Assert.Equal(expectedPayment, payment);
        }

        [Fact]
        public void CalculatePayment_ShouldThrowExceptionForUnknownTourist()
        {
            // Arrange
            var mockCurrencyService = new MockCurrencyService();
            var mockTripRepository = new MockEmptyTripRepository();
            var calculator = new InsurancePaymentCalculator(mockCurrencyService, mockTripRepository);

            // Act ve Assert
            Assert.Throws<ArgumentException>(() => calculator.CalculatePayment("Unknown Tourist"));
        }
    }
}

// MockTripRepository
public class MockTripRepository : ITripRepository
{
    public TripDetails LoadTrip(string touristName)
    {
        return new TripDetails
        {
            TouristName = touristName,
            FlyCost = 1000m,
            AccomodationCost = 2000m,
            ExcursionCost = 500m
        };
    }
}

public class MockEmptyTripRepository : ITripRepository
{
    public TripDetails LoadTrip(string touristName)
    {
        return null;
    }
}

// MockCurrencyService
public class MockCurrencyService : ICurrencyService
{
    public decimal LoadCurrencyRate()
    {
        return 1.2m;
    }
}