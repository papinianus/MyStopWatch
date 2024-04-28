using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace MyStopWatch.Models
{
    internal class MainModel : IDisposable
    {
        internal State State { get; private set; } = State.Initial;
        private Stopwatch Stopwatch { get; } = new();
        private Timer Timer { get; } = new() { Interval = 10 };
        private MyStopWatchContext DbContext { get; set; }
        internal BindingList<Work> Works { get; private set; }
        internal int CurrentWork { get; private set; } = -1;
        internal void SetTimerEvent(EventHandler timerTrigger) => Timer.Tick += timerTrigger;

        internal int InitialSelection() => Works.FirstOrDefault(x => string.IsNullOrWhiteSpace(x.Title))?.Id ?? -1;

        internal MainModel()
        {
            DbContext = new MyStopWatchContext();
#if DEBUG
            DbContext.Database.EnsureDeleted();
#endif
            DbContext.Database.Migrate();
            var item = DbContext.Works.FirstOrDefault();
            if (item == null)
            {
                DbContext.Works.Add(new Work { Title = "Sample" });
                DbContext.SaveChanges();
            }
            DbContext.Works.Load();

            Works = DbContext.Works.Local.ToBindingList();
            CurrentWork = InitialSelection();
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
            CurrentWork = InitialSelection();
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

        internal void SelectWork(int selectedValue)
        {
            CurrentWork = selectedValue;
        }

        #endregion

        #region UI effecting

        internal string GetElapsed() => Stopwatch.Elapsed.ToHumanReadable();

        internal bool CanStart() => State switch
        {
            State.Initial => CurrentWork != -1 && !string.IsNullOrWhiteSpace(Works.First(x=>x.Id == CurrentWork).Title),
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

        public void Dispose()
        {
            Timer.Dispose();
            DbContext.Dispose();
        }
    }

    internal enum State
    {
        Initial,
        Stop,
        Running,
    }
}
