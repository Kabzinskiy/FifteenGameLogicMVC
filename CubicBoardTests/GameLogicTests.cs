using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CubicBoard.Tests
{
    [TestClass()]
    public class GameLogicTests
    {
        [TestMethod()]
        public void GameLogicTest()
        {
            
        }

        [TestMethod()]
        public void StartTest()
        {
            GameLogic game = new GameLogic(4);
            game.Start();
            Assert.AreEqual(1, game.GetDigitAt(0, 0));
            Assert.AreEqual(2, game.GetDigitAt(1, 0));
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
            Assert.AreEqual(15, game.GetDigitAt(2, 3));
            Assert.AreEqual(0, game.GetDigitAt(3, 3));

        }

        [TestMethod()]
        public void PressAtTest()
        {
            GameLogic game = new GameLogic(4);
            game.Start();
            game.PressAt(2, 3);
            Assert.AreEqual(0, game.GetDigitAt(2, 3));
            Assert.AreEqual(15, game.GetDigitAt(3, 3));
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDigitAt(2, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 3));
        }

        [TestMethod()]
        public void GetDigitAtTest()
        {
            GameLogic game = new GameLogic(4);
            game.Start();
            Assert.AreEqual(0, game.GetDigitAt(-2, -12));
            Assert.AreEqual(0, game.GetDigitAt(-5, 2));
            Assert.AreEqual(0, game.GetDigitAt(22, 2));
        }

        [TestMethod()]
        public void SolvedTest()
        {
            GameLogic game = new GameLogic(4);
            game.Start();
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}