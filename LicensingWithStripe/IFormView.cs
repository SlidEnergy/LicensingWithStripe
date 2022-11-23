using System;
using System.Windows.Forms;

namespace LicensingWithStripe
{
    public interface IFormView
    {
        DialogResult ShowDialog();
        void Show();
        event EventHandler Load;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        DialogResult DialogResult { get; }

        void Close();
        void Dispose();

        bool Disposing { get; }
        bool IsDisposed { get; }
    }
}
