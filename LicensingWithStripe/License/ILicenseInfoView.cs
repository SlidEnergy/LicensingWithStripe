using LicenseSpring;
using System;

namespace LicensingWithStripe.License
{
    internal interface ILicenseInfoView : IFormView
    {
        event EventHandler<EventArgs> ActivateLicense;

        ILicense License { get; set; }
    }
}
