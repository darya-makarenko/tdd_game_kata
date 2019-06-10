using System;
using System.Runtime.InteropServices;
using Bowling;
using Xunit;

namespace BowlingTest
{
    public class GameResultsTests: IDisposable
    {
        private Game game;

        public GameResultsTests()
        {
            game = new Game();
        }

        [Theory]
        [InlineData(6)]
        [InlineData(5)]
        [InlineData(0)]
        public void OneRollTest(int pins)
        {
            game.Roll(pins);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(4)]
        public void ConstantScoreGameTest(int pins)
        {
            RollDefinedNumberOfPins(20, pins);
            int score = game.Score();
            Assert.Equal(score, 20 * pins);
        }

        private void RollDefinedNumberOfPins(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        public void Dispose()
        {
            game = null;
        }
    }
}
