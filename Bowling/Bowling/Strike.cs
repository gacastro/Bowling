namespace Bowling
{
    public class Strike : Ball
    {
        public override int PinsKnocked => MaximumPinsKnocked;
    }
}