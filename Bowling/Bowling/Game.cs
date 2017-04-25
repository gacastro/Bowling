using System;
using System.Collections.Generic;
using System.Linq;

using static System.String;

namespace Bowling
{
    public class Game
    {
        private const int MaximumSizeOfSet = 32;
        private const int MiminumSizeOfSet = 22;
        private const int NumberOfFrames = 10;
        private IList<Frame> _frames;

        public int Score => _frames.Sum((Func<Frame, int>) EachFrameScore);

        public Game(string frameSet)
        {
            if (Invalid(frameSet))
                throw new ArgumentException();

            SetFrames(frameSet);
        }

        private static bool Invalid(string frameSet)
        {
            if (IsNullOrWhiteSpace(frameSet))
                return true;

            var wrongSize = frameSet.Length > MaximumSizeOfSet || frameSet.Length < MiminumSizeOfSet;
            var hasInvalidScores = frameSet.Any(InvalidScore);

            return wrongSize || hasInvalidScores;
        }

        private static bool InvalidScore(char score)
        {
            var validScores = new List<char> { 'X', '/', '-', '|' };

            return !validScores.Contains(score) && !char.IsNumber(score);
        }

        private void SetFrames(string frameSet)
        {
            var splittedFrameSet = frameSet.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            _frames = splittedFrameSet.Take(NumberOfFrames - 1).Select(frame => new Frame(frame)).ToList();

            _frames.Add(
                splittedFrameSet.Length == NumberOfFrames
                    ? new LastFrame(splittedFrameSet[NumberOfFrames - 1])
                    : new LastFrame(splittedFrameSet[NumberOfFrames - 1], splittedFrameSet[NumberOfFrames]));
        }

        private int EachFrameScore(Frame frame)
        {
            if (frame is LastFrame)
                return frame.GetScore();

            var result = frame.GetScore();

            if (frame.HasStrike)
                result += GetScoreNextTwoBalls(frame);

            if (frame.HasSpare)
                result += GetScoreNextBall(frame);

            return result;
        }

        private int GetScoreNextTwoBalls(Frame frame)
        {
            var currentFrameIndex = _frames.IndexOf(frame);
            var nextFrame = _frames[currentFrameIndex + 1];

            var score = nextFrame.FirstBall.PinsKnocked;

            if (nextFrame.SecondBall != null)
            {
                score += nextFrame.SecondBall.PinsKnocked;
            }
            else
            {
                if (nextFrame is LastFrame)
                {
                    var lastFrame = nextFrame as LastFrame;
                    score += lastFrame.FirstBonusBall.PinsKnocked;
                }
                else
                {
                    var secondNextFrame = _frames[currentFrameIndex + 2];
                    score += secondNextFrame.FirstBall.PinsKnocked;
                }
            }

            return score;
        }

        private int GetScoreNextBall(Frame frame)
        {
            var nextFrame = _frames[_frames.IndexOf(frame) + 1];

            return nextFrame.FirstBall.PinsKnocked;
        }
    }
}