using LicenseSpring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensingWithStripe
{
    internal static class LicenseExtensions
    {
        public static string ToFormatString(this ILicense license)
        {
            var info = new StringBuilder();
            info.AppendLine("Type: " + license.Type());
            info.AppendLine("Status: " + license.Status());
            info.AppendLine("ValidityPeriod: " + license.ValidityPeriod());
            info.AppendLine("MaintenancePeriod: " + license.MaintenancePeriod());

            return info.ToString();
        }
    }
}
