using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    internal class MainModel
    {
        internal State state { get; private set; } = State.Initial;
        private Stopwatch stopwatch { get; } = new Stopwatch();
        private Timer timer { get; } = new Timer {Interval = 10 };

        internal void ToggleStartStop()
        {
            switch (state) {
                case State.Running:
                    state = State.Stop;
                    stopwatch.Stop();
                    timer.Stop();
                    return;
                case State.Stop:
                case State.Initial:
                    stopwatch.Start();
                    timer.Start();
                    state = State.Running;
                    return;
                default:
                    throw new InvalidDataException($"Unexpected State {state}");
            }
        }
        internal void Reset()
        {
            switch (state)
            {
                case State.Running:
                    throw new InvalidOperationException("Still Running");
                case State.Stop:
                    state = State.Initial;
                    stopwatch.Reset();
                    return;
                case State.Initial:
                    throw new InvalidOperationException("No afford to reset");
                default:
                    throw new InvalidDataException($"Unexpected State {state}");
            }
        }

        internal string GetElapsed() => stopwatch.Elapsed.ToHumanReadable();

        internal void SetTimerEvent(EventHandler timerTrigger) => 
            timer.Tick += timerTrigger;
    }
    internal enum State
    {
        Initial,
        Stop,
        Running,
    }
}
