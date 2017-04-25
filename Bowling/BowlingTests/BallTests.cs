using NUnit.Framework;

namespace Bowling.Tests
{
    [TestFixture]
    public class BallTests
    {
        [Test]
        public void should_create_strike_when_firstBall_is_a_strike()
        {
            var strike = Ball.FirstBall('X');
            Assert.That(strike, Is.TypeOf<Strike>());
        }

        [Test]
        public void should_create_gutter_ball_when_its_a_miss()
        {
            var gutter = Ball.FirstBall('-');
            Assert.That(gutter, Is.TypeOf<GutterBall>());
        }

        [Test]
        public void should_create_spare_when_secondBall_is_a_spare()
        {
            var spare = Ball.SecondBall('/', '3');
            Assert.That(spare, Is.TypeOf<Spare>());
        }

        [Test]
        public void should_create_hit_ball()
        {
            var strike = Ball.FirstBall('3');
            Assert.That(strike, Is.TypeOf<Hit>());
        }

        [TestCase('X', 10)]
        [TestCase('-', 0)]
        [TestCase('3', 3)]
        public void should_set_number_of_pins_knocked_down(char score, int expectedNumberOfPins)
        {
            var ball = Ball.FirstBall(score);

            Assert.That(ball.PinsKnocked, Is.EqualTo(expectedNumberOfPins));
        }
    }
}
