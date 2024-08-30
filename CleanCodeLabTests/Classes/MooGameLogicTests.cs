using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanCodeLab.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLab.Interfaces;
using static CleanCodeLabTests.Classes.MockObjects;

namespace CleanCodeLab.Classes.Tests
{
    [TestClass()]
    public class MooGameLogicTests
    {
        private IUI _mockUI;
        private ICustomRandom _customRandom;

        private MooGameLogic CreateMooGameLogic(string mockNumber)
        {
            _mockUI = new MockUI();
            _customRandom = new MockRandom(mockNumber);
            return new MooGameLogic(_mockUI, _customRandom);
        }
        [TestMethod()]
        public void GetGameGoalTest()
        {
            //Arrange
            string expectedGameGoal = "5689";
            var mooGameLogic = CreateMooGameLogic(expectedGameGoal);

            //Act
            var actualGameGoal = mooGameLogic.GetGameGoal();

            //Assert
            Assert.AreEqual(expectedGameGoal, actualGameGoal);
        }
        #region CalculateBullsAndCowsTests
        [TestMethod()]
        public void CalculateBullsAndCowsScore_AllDigitsMatch_ShouldReturnFourBulls()
        {
            //Arrange
            var mooGameLogic = CreateMooGameLogic("");
            string gameGoalNumber = "1234";
            string playersGuess = "1234";

            // Act
            var result = mooGameLogic.CalculateBullsAndCowsScore(gameGoalNumber, playersGuess);

            //Assert
            Assert.AreEqual("BBBB", result);
        }
        [TestMethod()]
        public void CalculateBullsAndCowsScore_AllDigitsMatchIncorrectly_ShouldReturnFourCows()
        {
            var mooGameLogic = CreateMooGameLogic("");
            string gameGoalNumber = "1234";
            string playersGuess = "4321";

            var result = mooGameLogic.CalculateBullsAndCowsScore(gameGoalNumber, playersGuess);

            Assert.AreEqual("CCCC", result);
        }
        [TestMethod()]
        public void CalculateBullsAndCowsScore_SomeDigitsMatchInCorrectAndIncorrectPositions_ShouldReturnBullsAndCows()
        {
            var mooGameLogic = CreateMooGameLogic("");
            string gameGoalNumber = "1234";
            string playersGuess = "1324";

            var result = mooGameLogic.CalculateBullsAndCowsScore(gameGoalNumber, playersGuess);

            Assert.AreEqual("BBCC", result);
        }
        [TestMethod()]
        public void CalculateBullsAndCowsScore_NoMatchingDigits_ShouldReturnNoBullsAndNoCows()
        {
            var mooGameLogic = CreateMooGameLogic("");
            string gameGoalNumber = "1234";
            string playersGuess = "5678";

            var result = mooGameLogic.CalculateBullsAndCowsScore(gameGoalNumber, playersGuess);

            Assert.AreEqual("", result);
        }
        [TestMethod()]
        public void CalculateBullsAndCowsScore_DuplicateDigitsInGuess_ShouldReturnCorrectNumberOfBullsAndCows()
        {
            var mooGameLogic = CreateMooGameLogic("");
            string gameGoalNumber = "1234";
            string playersGuess = "1122";

            var result = mooGameLogic.CalculateBullsAndCowsScore(gameGoalNumber, playersGuess);

            Assert.AreEqual("BC", result);
        }
        [TestMethod()]
        public void CalculateBullsAndCowsScore_EmptyStrings_ShouldReturnNoBullsAndNoCows()
        {
            var mooGameLogic = CreateMooGameLogic("");
            string gameGoalNumber = "1234";
            string playersGuess = "";

            var result = mooGameLogic.CalculateBullsAndCowsScore(gameGoalNumber, playersGuess);

            Assert.AreEqual("", result);
        }
        #endregion
    }
}