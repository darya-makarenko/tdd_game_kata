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

        [Theory]
        [MemberData(nameof(SparesTestData.TestData), MemberType = typeof(SparesTestData))]
        public void OneSpareTest(int spareFrameNumber, int firstRoll, int secondRoll)
        {
            int score = 0;

            for (int i = 0; i < 20; i++)
            {
                if (i / 2 == spareFrameNumber)
                {
                    game.Roll(firstRoll);
                    game.Roll(secondRoll);
                    i++;
                }
                else
                {
                    game.Roll(1);
                }
            }

            score = game.Score();
            Assert.Equal(score, 18 * 1 + 10 + 1);
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
