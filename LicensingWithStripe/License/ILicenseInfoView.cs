using LicenseSpring;

namespace LicensingWithStripe.License
{
    internal interface ILicenseInfoView : IFormView
    {
        event Action Activate;
        ILicense License { get; set; }
    }
}
