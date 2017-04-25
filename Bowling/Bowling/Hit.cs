namespace Bowling
{
    public class Hit : Ball
    {
        public Hit(char score)
        {
            PinsKnocked = int.Parse(score.ToString());
        }

        public override int PinsKnocked { get; }
    }
}