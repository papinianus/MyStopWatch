using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    internal class MainModel
    {
        internal State State { get; private set; } = State.Initial;
        private Stopwatch Stopwatch { get; } = new Stopwatch();
        private Timer Timer { get; } = new Timer { Interval = 10 };

        private List<string> Works { get; set; } = Enumerable.Empty<string>().ToList();
        internal IList<string> WorkTitles() => Works;
        internal int CurrentWork { get; private set; } = -1;
        internal void SetTimerEvent(EventHandler timerTrigger) => Timer.Tick += timerTrigger;

        internal int InitialIndex() => Works.FindIndex(x => x == string.Empty);

        internal MainModel()
        {
            Works = new List<string> { "たしざん1", "ひきざん2", "たしざん3", "ひきざん4" };
            CurrentWork = InitialIndex();
        }
        #region EventHandling
        internal void ToggleStartStop()
        {
            switch (State)
            {
                case State.Running:
                    State = State.Stop;
                    Stopwatch.Stop();
                    Timer.Stop();
                    return;
                case State.Stop:
                case State.Initial:
                    Stopwatch.Start();
                    Timer.Start();
                    State = State.Running;
                    return;
                default:
                    throw new InvalidDataException($"Unexpected State {State}");
            }
        }
        internal void Reset()
        {
            CurrentWork = InitialIndex();
            switch (State)
            {
                case State.Running:
                    throw new InvalidOperationException("Still Running");
                case State.Stop:
                    State = State.Initial;
                    Stopwatch.Reset();
                    return;
                case State.Initial:
                    throw new InvalidOperationException("No afford to reset");
                default:
                    throw new InvalidDataException($"Unexpected State {State}");
            }
        }
        internal void SelectWork(int selectedIndex)
        {
            CurrentWork = selectedIndex;
        }
        #endregion

        #region UI effecting
        internal string GetElapsed() => Stopwatch.Elapsed.ToHumanReadable();
        internal bool CanStart() => State switch
        {
            State.Initial => true && CurrentWork != -1 && !string.IsNullOrWhiteSpace(Works[CurrentWork]),
            State.Running => false,
            State.Stop => true,
            _ => throw new ArgumentOutOfRangeException(nameof(State))
        };
        internal bool CanStop() => State switch
        {
            State.Initial => false,
            State.Running => true,
            State.Stop => false,
            _ => throw new ArgumentOutOfRangeException(nameof(State))
        };
        internal bool CanReset() => State switch
        {
            State.Initial => false,
            State.Running => false,
            State.Stop => true,
            _ => throw new ArgumentOutOfRangeException(nameof(State))
        };
        internal string StartStopTitle() => State switch
        {
            State.Initial => "はじめる",
            State.Running => "とまって",
            State.Stop => "はじめる",
            _ => throw new ArgumentOutOfRangeException(nameof(State))
        };
        #endregion

    }
    internal enum State
    {
        Initial,
        Stop,
        Running,
    }
}
