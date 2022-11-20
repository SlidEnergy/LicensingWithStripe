using LicenseSpring;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            ActivateLicense(licenseKey);
        }

        private void _view_ActivateTrial(Customer customer)
        {
            var licenseKey = GenerateTrialLicense(customer);
            ActivateLicense(licenseKey);
        }

        public DialogResult ShowDialog()
        {
            return _view.ShowDialog();
        }

        public string GenerateTrialLicense(Customer customer)
        {
            try
            {
                var licenseId = _licenseManager.GetTrialLicense(customer);
                return licenseId.Key;
            }
            catch (LicenseSpringException e)
            {
                // TODO: handle errors by type
                _view.SetFailResult(e.Message);
                return "";
            }
        }

        public void ActivateLicense(string licenseKey)
        {
            try
            {
                var license = _licenseManager.ActivateLicense(licenseKey);

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
