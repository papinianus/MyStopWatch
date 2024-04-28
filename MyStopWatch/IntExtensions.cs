namespace MyStopWatch
{
    internal static class IntExtensions
    {
        internal static string PadLeft(this int number, int totalWidth = 2, char paddingChar = '0') => number.ToString().PadLeft(totalWidth, paddingChar);
    }
}
