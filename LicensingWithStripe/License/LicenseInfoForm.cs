using LicenseSpring;

namespace LicensingWithStripe.License
{
    public partial class LicenseInfoForm : DevExpress.XtraEditors.XtraForm, ILicenseInfoView
    {
        public event Action Activate;

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

        public void DisplayLicenseInfo()
        {
            if(_license == null)
            {
                memoEdit1.Text = "No license";
            }
            else
            {
                memoEdit1.Text = _license.ToFormatString();
            }

        }

        private void activateButton_Click(object sender, EventArgs e)
        {
            Activate?.Invoke();
        }
    }
}
