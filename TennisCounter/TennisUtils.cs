using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TennisCounterLibrary;

namespace TennisCounter
{
    internal class TennisUtils
    {
        public static void ShowWinner(string name)
        {
            string messageBoxText = "Game scores reset!";
            string caption = String.Format("{0} has won", name);
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Asterisk;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        public static void ShowWinnerSet(string name)
        {
            string messageBoxText = "New Set starts";
            string caption = String.Format("{0} has won the set", name);
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Asterisk;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        public static void ShowSideChange()
        {
            string messageBoxText = "A Side Change must be done in order to continue!";
            string caption = String.Format("Change Sides");
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Exclamation;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
        }

        public static void checkChanges(SuperMatchModel Matchmodel)
        {
            // Check for side change
            if (Matchmodel.IsChangeSides())
            {
                ShowSideChange();
            }

            // Check if set won for Three Set Match mode only
            if (Matchmodel is ThreeSetMatch)
            {
                Player setWinner = Matchmodel.CheckSetWon();
                if (setWinner != null)
                {
                    setWinner.Score.Sets++;
                    if (Matchmodel.CheckWinner() == null)
                    {
                    // Do not show set winner when it is over
                    ShowWinnerSet(setWinner.Name);
                    }
                    Matchmodel.ResetGames();
                }
            }

            // Check for winner
            string winner = Matchmodel.CheckWinner();
            if (winner != null)
            {
                // Show notification
                ShowWinner(winner);
                Matchmodel.ResetScores();

            }


            // Check for serve change
            if (Matchmodel.IsChangeServe())
            {
                Matchmodel.Player1.HasServe = Matchmodel.Player1.HasServe ? false : true;
                Matchmodel.Player2.HasServe = Matchmodel.Player2.HasServe ? false : true;

            }
        }
    }
}
