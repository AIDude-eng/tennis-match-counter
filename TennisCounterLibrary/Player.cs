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
