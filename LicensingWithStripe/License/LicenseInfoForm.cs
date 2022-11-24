using LicenseSpring;
using System;

namespace LicensingWithStripe.License
{
    public partial class LicenseInfoForm : DevExpress.XtraEditors.XtraForm, ILicenseInfoView
    {
        public event EventHandler<EventArgs> ActivateLicense;

        private ILicense _license;
        public ILicense License 
        { 
            get => _license;
            set
            {
                _license = value;
                DisplayLicenseInfo();
            }
        }

        public LicenseInfoForm()
        {
            InitializeComponent();
        }

        private void DisplayLicenseInfo()
        {
            if(_license == null)
            {
                uxLicenseInfo.Text = "No license";
            }
            else
            {
                uxLicenseInfo.Text = _license.ToFormatString();
            }

        }

        private void uxActivate_Click(object sender, EventArgs e)
        {
            ActivateLicense?.Invoke(this, EventArgs.Empty);
        }
    }
}
