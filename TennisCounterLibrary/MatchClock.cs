using System.Windows;
using System.Timers;
using System.Diagnostics;
using System.Windows.Controls;

namespace TennisCounterLibrary
{
    public class MatchClock
    {
        private const string _startingTime = "00:00:00";
        private readonly Timer _timer;
        private readonly Stopwatch _stopwatch;
        private readonly Label clockText;
        public bool isStopped = false;

        public MatchClock(Label clockText)
        {
            this.clockText = clockText;
            clockText.Content = _startingTime;
            _stopwatch = new Stopwatch();
            _timer = new Timer(1000);
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() => clockText.Content = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss"));
        }

        public void Start()
        {
            _stopwatch.Start();
            _timer.Start();
            isStopped = false;
        }

        public void Stop()
        {
            _stopwatch.Stop();
            _timer.Stop();
            isStopped = true;
        }

        public void Reset()
        {
            _stopwatch.Reset();
            clockText.Content = _startingTime;
        }
    }

}
