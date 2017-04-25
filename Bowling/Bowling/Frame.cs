using System;
using static System.String;

namespace Bowling
{
    public class Frame
    {
        private const char Strike = 'X';
        private const char Spare = '/';
        protected const int FrameMaxSize = 2;
        protected const int FrameMinSize = 1;

        public Ball FirstBall { get; }
        public Ball SecondBall { get; }
        public bool HasStrike => FirstBall is Strike;
        public bool HasSpare => SecondBall is Spare;

        public Frame(string frame)
        {
            if(Invalid(frame))
                throw new ArgumentException();

            FirstBall = Ball.FirstBall(frame[0]);

            if (frame.Length == FrameMaxSize)
                SecondBall = Ball.SecondBall(frame[1], frame[0]);
        }

        private static bool Invalid(string frame)
        {
            if (IsNullOrWhiteSpace(frame))
                return true;

            var invalidStrike = frame[0] == Strike && frame.Length == FrameMaxSize;
            var wrongSize = frame.Length < FrameMinSize || frame.Length > FrameMaxSize;
            var invalidSpare = frame[0] == Spare;

            return wrongSize || invalidSpare || invalidStrike;
        }

        public virtual int GetScore() => 
            FirstBall.PinsKnocked + (SecondBall?.PinsKnocked ?? Ball.MinimumPinsKnocked);
    }
}