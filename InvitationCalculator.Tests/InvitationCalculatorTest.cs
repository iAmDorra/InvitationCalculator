using NSubstitute;

namespace InvitationCalculator.Tests
{
    [TestClass]
    public class InvitationCalculatorTest
    {
        [TestMethod]
        public void CalculateInvitationDate_ShouldReturnCorrectDate()
        {
            // Arrange
            var birthDate = new DateTime(1993, 8, 25);
            var currentDate = new DateTime(2023, 5, 23);
            var expectedInvitationDate = new DateTime(2023, 10, 25);
            var screeningService = Substitute.For<ScreeningService>();
            screeningService.GetMonths(ScreeningType.Uterus).Returns(2);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, ScreeningType.Uterus);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }
    }

    public class InvitationCalculator
    {
        private readonly ScreeningService _screeningService;

        public InvitationCalculator(ScreeningService screeningService)
        {
            _screeningService = screeningService;
        }

        public DateTime CalculateInvitationDate(DateTime birthDate, DateTime currentDate, ScreeningType screeningType)
        {
            int monthsToAdd = _screeningService.GetMonths(screeningType);
            DateTime invitationDate = new DateTime(currentDate.Year, birthDate.Month, birthDate.Day).AddMonths(monthsToAdd);
            return invitationDate;
        }
    }

    public interface ScreeningService
    {
        int GetMonths(ScreeningType screeningType);
    }

    public enum ScreeningType
    {
        Uterus
    }
}