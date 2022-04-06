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
using System.Diagnostics;

namespace TennisCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MatchModesIndexer modes = new MatchModesIndexer();
        int curridx = 0;
        MatchModesIndexer.MatchModes CurrentMatchMode { get; set; }



        public MainWindow()
        {
            InitializeComponent();
            CurrentMatchMode = modes[curridx];
            MatchModeLabel.Content = modes.MatchModeTitles[curridx];
        }

        private void StartMatchButton(object sender, RoutedEventArgs e)
        {
            // Instantiate Matchmodel that corresponds to the selected mode
            SuperMatchModel MatchModel;
            if (CurrentMatchMode == MatchModesIndexer.MatchModes.ChampTieBreak)
            {
                MatchModel = new ChampTieBreak();
            } else if (CurrentMatchMode == MatchModesIndexer.MatchModes.ThreeSets)
            {
                MatchModel = new ThreeSetMatch();
            } else
            {
                MatchModel = new ChampTieBreak();
            }
            string Player1Name1 = Player1NameInput.Text;
            MatchModel.Player1 = new Player(Player1Name1);
            MatchModel.Player1.HasServe = true;
            string Player1Name2 = Player2NameInput.Text;
            MatchModel.Player2 = new Player(Player1Name2);
            MatchModel.Player2.HasServe = false;
            Main.NavigationService.Navigate(new MatchPage(MatchModel));
        }

        private void Select_Mode_Button(object sender, RoutedEventArgs e)
        {
            curridx++;
            if (curridx >= modes.GetNumModes())
            {
                curridx = 0;
            }
            CurrentMatchMode = modes[curridx];
            MatchModeLabel.Content = modes.MatchModeTitles[curridx];
            Trace.WriteLine(modes[curridx] == MatchModesIndexer.MatchModes.ChampTieBreak);
        }
    }
}
