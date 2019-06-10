using System;
using Bowling;
using Xunit;

namespace BowlingTest
{
    public class InitializationTests: IDisposable
    {
        private Game game;

        public InitializationTests()
        {
            game = new Game();
        }

        [Fact]
        public void NewGameNotNull()
        {
            Assert.NotNull(game);
        }

        [Fact]
        public void RollMethodIsAvailable()
        {
            var gameType = game.GetType();
            var methodInfo = gameType.GetMethod("Roll");

            Assert.NotNull(methodInfo);
        }

        [Fact]
        public void ScoreMethodIsAvailable()
        {
            var gameType = game.GetType();
            var methodInfo = gameType.GetMethod("Score");

            Assert.NotNull(methodInfo);
        }

        public void Dispose()
        {
            game = null;
        }
    }
}
