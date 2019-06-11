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

        [Theory]
        [InlineData(1, 10)]
        [InlineData(6, 8)]
        [InlineData(5, 7)]
        public void TooManyPinsInFrameNotAllowed(int firstRoll, int secondRoll)
        {
            Action act = () =>
            {
                game.Roll(firstRoll);
                game.Roll(secondRoll);
            };
            Assert.Throws<ArgumentException>(act);
        }


        public void Dispose()
        {
            game = null;
        }
    }
}