using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TennisCounterLibrary;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace TennisCounter
{
    /// <summary>
    /// Interaction logic for MatchPage.xaml
    /// </summary>
    public partial class MatchPage: INotifyPropertyChanged
    {
        public SuperMatchModel Matchmodel;
        public string Score1
        {
            get { return Matchmodel.ParseScore1(); }
        }

        public string Score2
        {
            get { return Matchmodel.ParseScore2(); }
        }

        public string Serve1
        {
            get
            {
                return Matchmodel.Player1.HasServe ? "Serving" : "";
            }
        }

        public string Serve2
        {
            get
            {
                return Matchmodel.Player2.HasServe ? "Serving" : "";
            }
        }
        private MainWindow main;

        public MatchPage(SuperMatchModel Matchmodel, MainWindow main)
        {
            this.main = main;
            main.Main.Visibility = Visibility.Visible;
            InitializeComponent();
            DataContext = this;
            this.Matchmodel = Matchmodel;

            // Insert names if available else default
            if (!string.IsNullOrEmpty(this.Matchmodel.Player1.Name))
            {
                Player1.Content = this.Matchmodel.Player1.Name;
            } else
            {
                this.Matchmodel.Player1.Name = "Player 1";
            }
            if (!string.IsNullOrEmpty(this.Matchmodel.Player2.Name))
            {
                Player2.Content = this.Matchmodel.Player2.Name;
            } else
            {
                this.Matchmodel.Player2.Name = "Player 2";
            }

            // Set modename as title
            ModeName.Content = Matchmodel.ModeName;

            // Define who starts serving
            OnPropertyChanged("Serve1");
            OnPropertyChanged("Serve2");

            // Instantiate Match Clock
            Matchmodel.MatchClock = new MatchClock(Clock);
            Matchmodel.MatchClock.Start();
        }

        private void PointP1Button_Click(object sender, RoutedEventArgs e)
        {
            // Increase score
            Matchmodel.UpdateScore(true);
            OnPropertyChanged("Score1");
            TennisUtils.checkChanges(Matchmodel);

            // Update UI
            UpdateUIBindings();
        }

        private void PointP2Button_Click(object sender, RoutedEventArgs e)
        {
            // Increase Score
            Matchmodel.UpdateScore(false);
            OnPropertyChanged("Score2");
            TennisUtils.checkChanges(Matchmodel);

            // Update UI
            UpdateUIBindings();
        }

        private void UpdateUIBindings()
        {
            OnPropertyChanged("Score1");
            OnPropertyChanged("Score2");
            OnPropertyChanged("Serve1");
            OnPropertyChanged("Serve2");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Matchmodel.ResetScores();
            // Update UI
            UpdateUIBindings();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            main.Main.Visibility = Visibility.Hidden;
        }

        private void StopClockButton_Click(object sender, RoutedEventArgs e)
        {
            if (Matchmodel.MatchClock.isStopped)
            {
                Matchmodel.MatchClock.Start();
                StopClockButton.Content = "Stop Clock";
            } else
            {
                Matchmodel.MatchClock.Stop();
                StopClockButton.Content = "Start Clock";
            }
        }

        private void ResetClockButton_Click(object sender, RoutedEventArgs e)
        {
            Matchmodel.MatchClock.Stop();
            StopClockButton.Content = "Start Clock";
            Matchmodel.MatchClock.Reset();
        }
    }
}
