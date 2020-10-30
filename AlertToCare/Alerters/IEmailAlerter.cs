namespace AlertToCare.Alerters
{
    public interface IEmailAlerter
    {
            object SendEmailVitalAlert(VitalAlertEmailFormat email);
    }
}
