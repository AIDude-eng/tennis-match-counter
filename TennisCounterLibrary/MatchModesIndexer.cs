using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisCounterLibrary
{
    public class MatchModesIndexer
    {
        public enum MatchModes { ChampTieBreak, ThreeSets };
        public string[] MatchModeTitles = new string[] { "Champions Tie Break", "3 Set Match" };
        private readonly List<MatchModes> values = Enum.GetValues(typeof(MatchModes)).Cast<MatchModes>().ToList();

        public MatchModes this[int i]
        {
            get { return values[i]; }
        }

        public int GetNumModes()
        {
            return values.Count;
        }
    }
}
