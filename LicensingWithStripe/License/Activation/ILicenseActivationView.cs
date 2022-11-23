using LicenseSpring;
using System;

namespace LicensingWithStripe.License.Activation
{
    internal interface ILicenseActivationView : IFormView
    {
        // TODO: Don't use model from licenseSpring in the views
        event Action<Customer> ActivateTrial;

        event Action<string> ActivateCommercial;

        void SetSuccessResult(ILicense license);
        void SetFailResult(string errorMessage);
    }
}
