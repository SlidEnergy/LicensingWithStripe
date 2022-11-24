using LicenseSpring;
using LicensingWithStripe.License.Activation;
using System;

namespace LicensingWithStripe
{
    public partial class LicenseActivationWizard : DevExpress.XtraEditors.XtraForm, ILicenseActivationView
    {
        public event Action<Customer> ActivateTrial;
        public event Action<string> ActivateCommercial;

        public LicenseActivationWizard()
        {
            InitializeComponent();
            radioGroup1.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(LicenseType.TimeLimited, "Trial license"));
            radioGroup1.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(LicenseType.Subscription, "Commercial license"));
            wizardControl1.SelectedPage = wizardPage1;
        }

        public void SetSuccessResult(ILicense license)
        {
            // TODO: Design and color text
            completionWizardPage1.FinishText = license.ToFormatString();
            wizardControl1.SelectedPage = completionWizardPage1;
        }

        public void SetFailResult(string errorMessage)
        {
            // TODO: Design and color text
            completionWizardPage1.FinishText= errorMessage;
            wizardControl1.SelectedPage = completionWizardPage1;
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (e.Page == wizardPage1)
            {
                ProcessStep1(e);
            }
            else if (e.Page == wizardPage2)
            {
                ProcessStep2(e);
            }
            else if (e.Page == wizardPage3)
            {
                ProcessStep3(e);
            }
            else if (e.Page == wizardPage4)
            {
                ProcessStep4(e);
            }
        }

        private void ProcessStep1(DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            var licenseType = (LicenseType)radioGroup1.EditValue;
            if (licenseType == LicenseType.TimeLimited)
            {
                e.Handled= true;
                wizardControl1.SelectedPage = wizardPage2;
            }
            else
            {
                wizardControl1.SelectedPage = wizardPage3;
            }

            e.Handled= true;
        }

        public void ProcessStep2(DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            var email = emailTextEdit.Text.Trim();
            var company = companyTextEdit.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(company))
                // TODO: add some message for user
                return;

            // TODO: disable next button

            e.Handled = true;
            wizardControl1.SelectedPage = wizardPage4;
        }

        public void ProcessStep3(DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            var serialKey = licenseKeyTextEdit.Text.Trim();

            if (string.IsNullOrEmpty(serialKey))
                // TODO: add some message for user
                return;

            // TODO: disable next button

            e.Handled = true;
            wizardControl1.SelectedPage = wizardPage4;
        }

        public void ProcessStep4(DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            var licenseType = (LicenseType)radioGroup1.EditValue;
            if (licenseType == LicenseType.TimeLimited)
            {
                var email = emailTextEdit.Text.Trim();
                var company = companyTextEdit.Text.Trim();

                // TODO: add city and country
                var customer = new Customer(email) { Company = company };

                ActivateTrial?.Invoke(customer);
            }
            else
            {
                var serialKey = licenseKeyTextEdit.Text.Trim();

                ActivateCommercial?.Invoke(serialKey);
            }
        }
    }
}