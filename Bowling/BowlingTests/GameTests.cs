using System;
using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class GameTests
    {
        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("qqrewvsfg!@#$%$^&*)")]
        [TestCase("91|91|91|91|91|91|91|91|91|X||XXX")]
        [TestCase("X|X|X|X|X|X|X|X|X|91|")]
        public void should_throw_when_the_frame_set_is_invalid(string frameSet)
        {
            Assert.Throws<ArgumentException>(() => new Game(frameSet));
        }

        [TestCase("X|X|X|X|X|X|X|X|X|X||XX", 300)]
        [TestCase("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90)]
        [TestCase("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150)]
        [TestCase("X|7/|9-|X|-8|8/|-6|X|X|X||81", 167)]
        [TestCase("X|3/|25|-6|X|X|5/|36|15|X||7/", 138)]
        [TestCase("34|7/|2/|X|X|X|-5|9/|X|X||5/", 174)]
        public void should_calculate_the_game_score(string frameSet, int expectedScore)
        {
            var game = new Game(frameSet);

            Assert.That(game.Score, Is.EqualTo(expectedScore));
        }
    }
}
