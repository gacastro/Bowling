namespace Bowling
{
    public class LastFrame : Frame
    {
        public Ball FirstBonusBall { get; }
        public Ball SecondBonusBall { get; }

        public LastFrame(string frame) : base(frame) { }

        public LastFrame(string frame, string bonusFrame) : base(frame)
        {
            FirstBonusBall = Ball.FirstBall(bonusFrame[0]);

            if (bonusFrame.Length == FrameMaxSize)
                SecondBonusBall = Ball.SecondBonusBall(bonusFrame[1], bonusFrame[0]);
        }

        public override int GetScore()
        {
            var score = base.GetScore();
            var bonusScore = (FirstBonusBall?.PinsKnocked ?? Ball.MinimumPinsKnocked) + (SecondBonusBall?.PinsKnocked ?? Ball.MinimumPinsKnocked);

            return score + bonusScore;
        }
    }
}