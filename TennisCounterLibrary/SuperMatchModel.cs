using System;

namespace TennisCounterLibrary
{
    public abstract class SuperMatchModel
    {
        abstract public string ModeName { get; }
        public MatchClock MatchClock;
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public abstract void UpdateScore(bool p1Scored);

        public abstract string CheckWinner();

        public abstract bool IsChangeSides();

        public abstract bool IsChangeServe();

        public abstract string ParseScore1();
        public abstract string ParseScore2();
        public Player CheckSetWon()
        {
            if (Player1.Score.Games >= 6 && Math.Abs(Player1.Score.Games - Player2.Score.Games) > 1 && CheckWinner() == null)
            {
                return Player1;
            }
            else if (Player2.Score.Games >= 6 && Math.Abs(Player1.Score.Games - Player2.Score.Games) > 1 && CheckWinner() == null)
            {
                return Player2;
            }
            else
            {
                return null;
            }
        }

        public void ResetScores()
        {
            Player1.Score = new ScoreModel();
            Player2.Score = new ScoreModel();
        }

        public void ResetPoints()
        {
            Player1.Score.Points = 0;
            Player2.Score.Points = 0;
        }

        public void ResetGames()
        {
            Player1.Score.Games = 0;
            Player2.Score.Games = 0;
        }
    }

    public class ChampTieBreak : SuperMatchModel
    {
        public override string ModeName { get; } = "Champions Tie Break";
        public override void UpdateScore(bool p1Scored)
        {
            if (p1Scored)
            {
                Player1.Score.Points++;
            } else
            {
                Player2.Score.Points++;
            }
        }

        public override string CheckWinner()
        {
            if (Player1.Score.Points >= 11 && Math.Abs(Player1.Score.Points - Player2.Score.Points) > 1)
            {
                return Player1.Name;
            } else if (Player2.Score.Points >= 11 && Math.Abs(Player1.Score.Points - Player2.Score.Points) > 1)
            {
                return Player2.Name;
            } else
            {
                return null;
            }
        }

        public override bool IsChangeSides()
        {
            if ((Player1.Score.Points + Player2.Score.Points) % 6 == 0 && CheckWinner() == null && !(Player1.Score.Points == 0 && Player2.Score.Points == 0))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public override bool IsChangeServe()
        {
            if ((Player1.Score.Points + Player2.Score.Points) % 2 == 1) {
                return true;
            } else
            {
                return false;
            }
        }

        public override string ParseScore1()
        {
            return Player1.Score.Points.ToString();
        }

        public override string ParseScore2()
        {
            return Player2.Score.Points.ToString();
        }
    }

    public class ThreeSetMatch : SuperMatchModel
    {
        public override string ModeName { get; } = "Three Set Match";
        public override void UpdateScore(bool p1Scored)
        {
            if (p1Scored)
            {
                UpdatePoints(Player1.Score, Player2.Score);
            }
            else
            {
                UpdatePoints(Player2.Score, Player1.Score);
            }
        }

        public void UpdatePoints(ScoreModel Score1, ScoreModel Score2)
        {
            // check if game was won
            if ((Score1.Points == 40 && Score2.Points < 40) || (Score1.Points == 50 && Score2.Points == 40))
            {
                ResetPoints();
                Score1.Games++;
            } else if (Score2.Points == 50)
            {
                Score2.Points = 40;
            }
            else if (Score1.Points == 40 && Score2.Points == 40)
            {
                Score1.Points = 50;
            }
            else if (Score1.Points <= 15)
            {
                Score1.Points += 15;
            }
            else if (Score1.Points == 30)
            {
                Score1.Points = 40;
            }
        }

        public override string CheckWinner()
        {
            if (Player1.Score.Sets >= 2)
            {
                return Player1.Name;
            } else if (Player2.Score.Sets >= 2)
            {
                return Player2.Name;
            } else
            {
                return null;
            }
        }

        public override bool IsChangeSides()
        {
            if ((Player1.Score.Games + Player2.Score.Games) % 2 == 1 && CheckWinner() == null && Player1.Score.Points == 0 && Player2.Score.Points == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool IsChangeServe()
        {
            if (Player1.Score.Points == 0 && Player2.Score.Points == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ParseScore1()
        {   
            string sets = Player1.Score.Sets.ToString();
            string games = Player1.Score.Games.ToString();
            string points = Player1.Score.Points == 50 ? "a.d." : Player1.Score.Points.ToString();
            string result = String.Format($"{sets} / {games} / {points}");
            return result;
        }

        public override string ParseScore2()
        {
            string sets = Player2.Score.Sets.ToString();
            string games = Player2.Score.Games.ToString();
            string points = Player2.Score.Points == 50 ? "a.d." : Player2.Score.Points.ToString();
            string result = String.Format($"{sets} / {games} / {points}");
            return result;
        }
    }
}
