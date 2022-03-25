using NUnit.Framework;
using TDD;

namespace TestProject1
{
    public class Tests
    {
        private BowlingGame bowlingGame;

        [SetUp]
        public void Setup()
        {
            bowlingGame = new BowlingGame();
        }

        [Test]
        public void TestBadGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, bowlingGame.Score());
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, bowlingGame.Score());
        }

        [Test]
        public void testOneSpare()
        {
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            bowlingGame.Roll(3);
            RollMany(17,0);

            Assert.AreEqual(16, bowlingGame.Score());
        }

        [Test]
        public void testOneStrike()
        {
            bowlingGame.Roll(10);
            bowlingGame.Roll(3);
            bowlingGame.Roll(4);
            RollMany(16, 0);
         
            Assert.AreEqual(24, bowlingGame.Score());
        }

        [Test]
        public void testPerfectGame()
        {
            RollMany(12, 10);

            Assert.AreEqual(300, bowlingGame.Score());
        }

        [Test]
        public void testLastFrameStrike()
        {
            RollMany(18, 0);
            bowlingGame.Roll(10);

            Assert.AreEqual(10, bowlingGame.Score());
        }

        [Test]
        public void testLastFrameSpare() 
        {
            RollMany(18, 0);
            bowlingGame.Roll(1);
            bowlingGame.Roll(9);

            Assert.AreEqual(10, bowlingGame.Score());
        }

        [Test]
        public void testRandomGameWithSpareAndStrake()
        {
            // 0
            bowlingGame.Roll(1);
            bowlingGame.Roll(5);
            // 6
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            // 6 + 10 + 3 = 19
            bowlingGame.Roll(3);
            bowlingGame.Roll(5);
            // 19 + 8 = 27
            bowlingGame.Roll(10);
            // 27 + 10 + 4 + 6 = 47
            bowlingGame.Roll(4);
            bowlingGame.Roll(6);
            // 47 + 10 + 7 = 64
            bowlingGame.Roll(7);
            bowlingGame.Roll(1);
            // 64 + 8 = 72
            bowlingGame.Roll(2);
            bowlingGame.Roll(6);
            // 72 + 8 = 80
            bowlingGame.Roll(10);
            // 80 + 10 + 10 + 5 = 105
            bowlingGame.Roll(10);
            // 100 + 10 + 5 + 5 = 125
            bowlingGame.Roll(5);
            bowlingGame.Roll(5);
            // 120 + 10 = 135
            Assert.AreEqual(135, bowlingGame.Score());
        }
        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                bowlingGame.Roll(pins);
            }
        }
    }
}