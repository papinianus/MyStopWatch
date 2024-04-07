using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace WinFormsApp1
{
    internal static class TimeSpanExtensions
    {
        internal static string ToHumanReadable(this TimeSpan time) =>
            $"{time.Hours.PadLeft()}:{time.Minutes.PadLeft()}:{time.Seconds.PadLeft()}.{time.Milliseconds.PadLeft(3)}";
    }
}
