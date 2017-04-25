namespace Bowling
{
    public abstract class Ball
    {
        public const int MaximumPinsKnocked = 10;
        public const int MinimumPinsKnocked = 0;
        public abstract int PinsKnocked { get; }

        public static Ball FirstBall(char score)
        {
            switch (score)
            {
                case 'X':
                    return new Strike();
                case '-':
                    return new GutterBall();
                default:
                    return new Hit(score);
            }
        }

        public static Ball SecondBall(char score, char previousScore)
        {
            switch (score)
            {
                case '/':
                    return new Spare(previousScore);
                case '-':
                    return new GutterBall();
                default:
                    return new Hit(score);
            }
        }

        public static Ball SecondBonusBall(char score, char previousScore)
        {
            switch (score)
            {
                case 'X':
                    return new Strike();
                case '/':
                    return new Spare(previousScore);
                case '-':
                    return new GutterBall();
                default:
                    return new Hit(score);
            }
        }
    }
}