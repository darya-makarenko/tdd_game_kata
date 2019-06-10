using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling
{
    public class Game
    {
        private int[] rolls = new int[21]; //9 frames with 2 rolls, 1 frame with 3 rolls possible
        private int currentRoll;

        public void Roll(int pins)
        {
            rolls[currentRoll] = pins;
            currentRoll++;
        }

        public int Score()
        {
            throw new NotImplementedException();
        }

    }
}
