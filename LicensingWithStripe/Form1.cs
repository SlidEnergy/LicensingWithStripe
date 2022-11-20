using LicensingWithStripe.License;

namespace LicensingWithStripe
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var presenter = new LicenseInfoPresenter(new LicenseInfoForm()))
            {
                presenter.ShowDialog();
            }
        }
    }
}