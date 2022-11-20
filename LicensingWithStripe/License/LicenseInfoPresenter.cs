﻿using DevExpress.Utils.About;
using LicenseSpring;
using LicensingWithStripe.License.Activation;
using System.ComponentModel;

namespace LicensingWithStripe.License
{
    internal class LicenseInfoPresenter : IDisposable
    {
        private ILicenseInfoView _view;

        private ILicense _currentLicense;
        private ILicenseManager _licenseManager;

        public LicenseInfoPresenter(ILicenseInfoView view)
        {
            _view = view;
            _view.Load += _view_Load;
            _view.Activate += _view_Activate;
            _licenseManager = LicenseSpring.LicenseManager.GetInstance();
        }

        private void _view_Activate()
        {
            using (var presenter = new LicenseActivationPresenter(new LicenseActivationWizard()))
            {
                presenter.SetLicenseManager(_licenseManager);
                presenter.ShowDialog();
            }
        }

        private void _view_Load(object? sender, EventArgs e)
        {
            Initialize();
        }

        public void Initialize()
        {
            // TODO: move to separated class Options and inject here
            var configuration = new Configuration(
              apiKey: "xxxxxxxxxxxxxxxxxx",
              sharedKey: "xxxxxxxxxxxxxxxxxxxxxx",
              productCode: "bc",
              appName: "BetterCharts",
              appVersion: "v0.1");

            _licenseManager.Initialize(configuration);

            var license = _licenseManager.CurrentLicense();

            if (license != null)
            {
                license.Check();
            }

            _view.License = license;
        }

        public DialogResult ShowDialog()
        {
            return _view.ShowDialog();
        }

        public void Dispose()
        {
            if (_view != null)
            {
                _view.Load -= _view_Load;
                _view.Activate -= _view_Activate;
                _view.Dispose();
            }
        }
    }
}