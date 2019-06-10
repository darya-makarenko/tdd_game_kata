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
            Assert.Equal(20 * pins, score);
        }

        [Theory]
        [MemberData(nameof(SparesTestData.TestData), MemberType = typeof(SparesTestData))]
        public void OneSpareTest(int spareFrameNumber, int firstRoll, int secondRoll)
        {
            int score = 0;

            int i = 0;
            while (i < 20)
            {
                if (i / 2 == spareFrameNumber - 1)
                {
                    game.Roll(firstRoll);
                    game.Roll(secondRoll);
                    i += 2;
                }
                else
                {
                    game.Roll(1);
                    i++;
                }
            }

            score = game.Score();
            Assert.Equal(18 * 1 + 10 + 1, score);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(8)]
        public void OneStrikeTest(int strikeFrameNumber)
        {
            int score = 0;

            int i = 0;
            while (i < 20)
            {
                if (i / 2 == strikeFrameNumber)
                {
                    game.Roll(10);
                    i++;
                }
                else
                {
                    game.Roll(1);
                }

                i++;
            }

            score = game.Score();
            Assert.Equal(18 * 1 + 10 + 2, score);
        }

        [Theory]
        [InlineData(4, 6, 6)]
        [InlineData(3, 7, 0)]
        [InlineData(5, 5, 8)]
        [InlineData(8, 2, 1)]
        public void LastFrameSpareTest(int firstRoll, int secondRoll, int thirdRoll)
        {
            int score = 0;

            RollDefinedNumberOfPins(18, 2);
            game.Roll(firstRoll);
            game.Roll(secondRoll);
            game.Roll(thirdRoll);

            score = game.Score();
            Assert.Equal(18 * 2 + 10 + thirdRoll, score);
        }

        [Theory]
        [InlineData(10, 5, 6)]
        [InlineData(10, 7, 0)]
        [InlineData(10, 5, 8)]
        [InlineData(10, 2, 1)]
        public void LastFrameStrikeTest(int firstRoll, int secondRoll, int thirdRoll)
        {
            int score = 0;

            RollDefinedNumberOfPins(18, 2);
            game.Roll(firstRoll);
            game.Roll(secondRoll);
            game.Roll(thirdRoll);

            score = game.Score();
            Assert.Equal(18 * 2 + 10 + secondRoll + thirdRoll, score);
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
