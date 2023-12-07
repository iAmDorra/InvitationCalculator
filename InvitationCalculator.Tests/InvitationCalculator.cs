namespace InvitationCalculator.Tests;

public class InvitationCalculator
{
    private readonly IScreeningService _screeningService;

    public InvitationCalculator(IScreeningService screeningService)
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