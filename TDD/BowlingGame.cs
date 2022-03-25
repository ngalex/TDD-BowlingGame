namespace TDD
{
    public class BowlingGame
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                //strike
                if (rolls[frameIndex] == 10)
                {
                    score += StrikeBonus(frameIndex);
                    frameIndex++;
                    continue;
                }  
                //spare
                if (isSpare(frameIndex))
                {
                    score += SpareBonus(frameIndex);
                    frameIndex += 2;
                    continue;
                } 

                score += sumBallsInFrame(frameIndex);
                frameIndex += 2;
            }

            return score;
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 2];
        }

        private int sumBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1]; 
        }

        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }
    }
}
