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
            if (pins == 10 && currentRoll != 18)
            {
                rolls[currentRoll + 1] = 0;
                currentRoll += 2;
            }
            else
            {
                currentRoll++;
            }
        }

        public int Score()
        {
            int score = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                int firstIndex = frame * 2;
                int secondIndex = frame * 2 + 1;

                if (rolls[firstIndex] == 10)
                {
                    if (frame == 9)
                    {
                        score += 10 + rolls[secondIndex] + rolls[secondIndex + 1];
                    }
                    else
                    {
                        score += 10 + rolls[secondIndex + 1] + rolls[secondIndex + 2];
                    }
                }
                else if (rolls[firstIndex] + rolls[secondIndex] == 10)
                {
                    score += 10 + rolls[secondIndex + 1];
                }
                else
                {
                    score += rolls[firstIndex] + rolls[secondIndex];
                }
            }

            return score;
        }

    }
}
