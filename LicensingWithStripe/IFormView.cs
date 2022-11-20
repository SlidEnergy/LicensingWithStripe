using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
