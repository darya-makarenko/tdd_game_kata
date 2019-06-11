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
            if (pins < 0 || pins > 10)
            {
                throw new ArgumentException();
            }

            //no more than 10 pins in one frame, except the last one
            if ((currentRoll < 19) && (currentRoll % 2 == 1) && (rolls[currentRoll - 1] + pins > 10))
            {
                throw new ArgumentException();
            }

            rolls[currentRoll] = pins;

            //we don't skip second roll in frame if it's the last frame
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
            //it can't be less then 20 rolls
            if (currentRoll < 20)
            {
                throw  new NullReferenceException();
            }

            //if there was a spare or a strike in 10th frame, we make 21st roll.
            if (currentRoll == 20 && (rolls[currentRoll - 3] + rolls[currentRoll - 2] >= 10))
            {
                throw new NullReferenceException();
            }

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
