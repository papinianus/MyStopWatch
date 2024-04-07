using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal static class IntExtensions
    {
        internal static string PadLeft(this int number, int totalWidth = 2, char paddingChar = '0') => number.ToString().PadLeft(totalWidth, paddingChar);
    }
}
