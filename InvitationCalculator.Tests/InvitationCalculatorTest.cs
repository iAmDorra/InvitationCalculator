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
            var screeningService = Substitute.For<IScreeningService>();
            screeningService.GetMonths(ScreeningType.Uterus).Returns(2);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, ScreeningType.Uterus);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }
    }
}