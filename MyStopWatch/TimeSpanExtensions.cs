namespace MyStopWatch
{
    internal static class TimeSpanExtensions
    {
        internal static string ToHumanReadable(this TimeSpan time) =>
            $"{time.Hours.PadLeft()}:{time.Minutes.PadLeft()}:{time.Seconds.PadLeft()}.{time.Milliseconds.PadLeft(3)}";
    }
}
