using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TennisCounterLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public ScoreModel Score = new ScoreModel();
        public bool HasServe { get; set; }

        public Player (string name)
        {
            Name = name;
        }


    }

    public class ScoreModel
    {
        public int Points { get; set; } = 0;
        public int Games { get; set; } = 0;
        public int Sets { get; set; } = 0;

    }
}
