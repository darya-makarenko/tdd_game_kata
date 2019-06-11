using System;
using Bowling;
using Xunit;
using Xunit.Sdk;

namespace BowlingTest
{
    public class EdgeCasesTests : IDisposable
    {
        private Game game;

        public EdgeCasesTests()
        {
            game = new Game();
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-10)]
        public void NegativePinsNotAllowed(int pins)
        {
            Action act = () => game.Roll(pins);
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(100)]
        public void TooManyPinsNotAllowed(int pins)
        {
            Action act = () => game.Roll(pins);
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(22)]
        [InlineData(25)]
        public void TooManyRollsNotAllowed(int rollsCount)
        {
            Action act = () =>
            {
                for (int i = 0; i < rollsCount; i++)
                {
                    game.Roll(0);
                }
            };
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(14)]
        public void TooFewRollsNotAllowed(int rollsCount)
        {
            Action act = () =>
            {
                int score = 0;
                for (int i = 0; i < rollsCount; i++)
                {
                    game.Roll(0);
                }
                score = game.Score();
            };
            Assert.Throws<NullReferenceException>(act);
        }

        public void Dispose()
        {
            game = null;
        }
    }
}