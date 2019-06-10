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

        public void Dispose()
        {
            game = null;
        }
    }
}
