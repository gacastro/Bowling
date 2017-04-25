using System;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    class FrameTests
    {
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("/2")]
        [TestCase("X2")]
        [TestCase("XXX")]
        public void should_throw_when_invalid_score(string score)
        {
            Assert.Throws<ArgumentException>(() => new Frame(score));
        }

        [TestCase("X", 10)]
        [TestCase("5/", 10)]
        [TestCase("9-", 9)]
        [TestCase("-6", 6)]
        [TestCase("36", 9)]
        public void should_calculate_the_score_of_a_frame(string frameScore, int expectedScore)
        {
            var frame = new Frame(frameScore);

            Assert.That(frame.GetScore(), Is.EqualTo(expectedScore));
        }

        [Test]
        public void should_say_if_a_frame_has_strike()
        {
            var frame = new Frame("X");

            Assert.That(frame.HasStrike, Is.True);
        }

        [Test]
        public void should_say_if_a_frame_has_spare()
        {
            var frame = new Frame("2/");

            Assert.That(frame.HasSpare, Is.True);
        }

        [Test]
        public void should_consider_bonus_frame_when_scoring_last_frame()
        {
            var lastFrame = new LastFrame("X", "XX");

            Assert.That(lastFrame.GetScore(), Is.EqualTo(30));
        }
    }
}
