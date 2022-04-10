public class RegistrationStatusViewModel : ViewModel
{
    public RegistrationStatus Status { get; set; }

    public RegistrationStatusViewModel(RegistrationStatus status)
    {
        Status = status;
    }
}
