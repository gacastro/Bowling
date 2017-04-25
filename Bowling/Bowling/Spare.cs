namespace Bowling
{
    public class Spare : Ball
    {
        private readonly int _previousScore;

        public Spare(char previousScore)
        {
            _previousScore = int.Parse(previousScore.ToString());
        }

        public override int PinsKnocked => MaximumPinsKnocked - _previousScore;
    }
}