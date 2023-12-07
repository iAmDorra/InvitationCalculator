using NSubstitute;

namespace InvitationCalculator.Tests
{
    [TestClass]
    public class InvitationCalculatorTest
    {
        [TestMethod]
        public void Should_increment_months_to_calculate_invitation_date_for_uterus_screening_type()
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

        [TestMethod]
        public void Should_increment_months_to_calculate_invitation_date_for_colon_screening_type()
        {
            // Arrange
            var screeningService = Substitute.For<IScreeningService>();
            var screeningType = ScreeningType.Colon;
            screeningService.GetMonths(screeningType).Returns(6);
            var birthDate = new DateTime(1993, 8, 25);
            var currentDate = new DateTime(2023, 5, 23);
            var expectedInvitationDate = new DateTime(2024, 02, 25);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, screeningType);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }

        [TestMethod]
        public void Should_increment_months_for_same_year_to_calculate_invitation_date_for_uterus_screening_type()
        {
            // Arrange
            var screeningService = Substitute.For<IScreeningService>();
            var screeningType = ScreeningType.Uterus;
            screeningService.GetMonths(screeningType).Returns(2);
            var birthDate = new DateTime(1993, 3, 25);
            var currentDate = new DateTime(2023, 5, 23);
            var expectedInvitationDate = new DateTime(2023, 5, 25);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, screeningType);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }

        [TestMethod]
        public void Should_increment_months_for_the_last_day_of_the_month_to_calculate_invitation_date_for_uterus_screening_type()
        {
            // Arrange
            var screeningService = Substitute.For<IScreeningService>();
            var screeningType = ScreeningType.Uterus;
            screeningService.GetMonths(screeningType).Returns(2);
            var birthDate = new DateTime(1993, 8, 31);
            var currentDate = new DateTime(2023, 5, 23);
            var expectedInvitationDate = new DateTime(2023, 10, 31);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, screeningType);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }

        [TestMethod]
        public void Should_increment_months_for_same_year_and_the_last_day_of_the_month_to_calculate_invitation_date_for_lung_screening_type()
        {
            // Arrange
            var screeningService = Substitute.For<IScreeningService>();
            var screeningType = ScreeningType.Lung;
            screeningService.GetMonths(screeningType).Returns(3);
            var birthDate = new DateTime(1993, 3, 31);
            var currentDate = new DateTime(2023, 5, 23);
            var expectedInvitationDate = new DateTime(2023, 6, 30);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, screeningType);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }

        [TestMethod]
        public void Should_increment_months_for_same_year_to_calculate_invitation_date_for_lung_screening_type()
        {
            // Arrange
            var screeningService = Substitute.For<IScreeningService>();
            var screeningType = ScreeningType.Lung;
            screeningService.GetMonths(screeningType).Returns(3);
            var birthDate = new DateTime(1993, 11, 30);
            var currentDate = new DateTime(2023, 5, 23);
            var expectedInvitationDate = new DateTime(2024, 2, 29);
            InvitationCalculator invitationCalculator = new InvitationCalculator(screeningService);

            // Act
            var result = invitationCalculator.CalculateInvitationDate(birthDate, currentDate, screeningType);

            // Assert
            Assert.AreEqual(expectedInvitationDate, result);
        }
    }
}