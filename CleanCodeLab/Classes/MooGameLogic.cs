using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes
{
    public interface ICustomRandom
    {
        public int NextNumber(int maxValue);
    }
    public class MyRandomWrapper : ICustomRandom
    {
        private Random _random;

        public MyRandomWrapper()
        {
            _random = new Random();
        }

        public int NextNumber(int maxValue)
        {
            int x = _random.Next(maxValue);
            return x;
        }
    }
    public class MooGameLogic : IGuessingGame
    {
        private IUI _ui;
        private ICustomRandom _customRandom;
        public string GameName => "Moo Game";
        public string GameInstruction => "New game:\n Guess a 4 digit number";
        public int PlayersNumberOfGuesses { get; set; } = 1;
        public bool GameIsOn { get; set; } = true;

        public MooGameLogic(IUI ui,ICustomRandom customRandom)
        {
            _ui = ui;
            _customRandom = customRandom;
        }

        public void PlayGame()
        {
            PlayersNumberOfGuesses = 1;
            string gameGoal = StartNewGame();
            PlayRound(gameGoal);
            _ui.DisplayOutput($"Correct, it took {PlayersNumberOfGuesses} guesses\n");
        }
        public string StartNewGame()
        {
            string gameGoal = GetGameGoal();
            DisplayInitialMessage();
            //comment out or remove next line to play real games!
            _ui.DisplayOutput("For practice, number is: " + gameGoal + "\n");
            return gameGoal;
        }
        public string GetGameGoal()
        {
            string gameGoal = String.Empty;
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = _customRandom.NextNumber(10).ToString();
                while (gameGoal.Contains(randomDigit))
                {
                    randomDigit = _customRandom.NextNumber(10).ToString();
                }
                gameGoal += randomDigit;
            }
            return gameGoal;
        }
        public void DisplayInitialMessage()
        {
            _ui.DisplayOutput(GameName);
            _ui.DisplayOutput(GameInstruction);
        }
        public void PlayRound(string gameGoal)
        {
            string playersGuess = _ui.GetUserInput();
            string guessOutcome = CalculateBullsAndCowsScore(gameGoal, playersGuess);
            _ui.DisplayOutput(guessOutcome);
            while (guessOutcome != "BBBB,")
            {
                PlayersNumberOfGuesses++;
                playersGuess = _ui.GetUserInput();
                guessOutcome = CalculateBullsAndCowsScore(gameGoal, playersGuess);
                _ui.DisplayOutput(guessOutcome);
            }
        }
        public string CalculateBullsAndCowsScore(string gameGoal, string playersGuess)
        { 
            int cows = 0, bulls = 0;
            playersGuess += "    "; 

            for (int i = 0; i < 4; i++)
            {
                if (playersGuess[i] == gameGoal[i]) bulls++;
                else if (playersGuess.Contains(gameGoal[i])) cows++;
            }

            return "BBBB".Substring(0, bulls) + "CCCC".Substring(0, cows);
        }
    }
}
