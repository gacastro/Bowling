namespace Bowling
{
    public class GutterBall : Ball
    {
        public override int PinsKnocked => MinimumPinsKnocked;
    }
}