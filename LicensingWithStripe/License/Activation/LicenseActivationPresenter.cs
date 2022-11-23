using LicenseSpring;
using System;
using System.Windows.Forms;

namespace LicensingWithStripe.License.Activation
{
    internal class LicenseActivationPresenter : IDisposable
    {
        private readonly ILicenseActivationView _view;
        private ILicenseManager _licenseManager;

        public LicenseActivationPresenter(ILicenseActivationView view)
        {
            _view = view;
            _view.ActivateTrial += _view_ActivateTrial;
            _view.ActivateCommercial += _view_ActivateCommercial;
            //_licenseManager = LicenseSpring.LicenseManager.GetInstance();
        }

        public void SetLicenseManager(ILicenseManager licenseManager)
        {
            _licenseManager= licenseManager;
        }

        private void _view_ActivateCommercial(string licenseKey)
        {
            var licenseI = LicenseID.FromKey(licenseKey);
            ActivateLicense(licenseI);
        }

        private void _view_ActivateTrial(Customer customer)
        {
            var licenseId = GenerateTrialLicense(customer);
            ActivateLicense(licenseId);
        }

        public DialogResult ShowDialog()
        {
            return _view.ShowDialog();
        }

        public LicenseID GenerateTrialLicense(Customer customer)
        {
            try
            {
                var licenseId = _licenseManager.GetTrialLicense(customer);
                return licenseId;
            }
            catch (LicenseSpringException e)
            {
                // TODO: handle errors by type
                _view.SetFailResult(e.Message);
                return null;
            }
        }

        public void ActivateLicense(LicenseID licenseId)
        {
            try
            {
                ILicense license = _licenseManager.ActivateLicense(licenseId);

                if (license != null)
                    _view.SetSuccessResult(license);
                else
                    _view.SetFailResult("Something went wrong. Please try again later or call to support.");
            }
            catch (LicenseSpringException e)
            {
                // TODO: handle errors by type
                _view.SetFailResult(e.Message);
            }
        }

        public void Dispose()
        {
            if (_view != null)
            {
                _view.ActivateTrial -= _view_ActivateTrial;
                _view.ActivateCommercial -= _view_ActivateCommercial;
                _view.Dispose();
            }
        }
    }
}
