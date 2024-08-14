using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes
{
    public class MooGameLogic : IMooGame
    {
        public string GenerateRandomFourDigitNumber()
        {
            Random numberGenerator = new Random();
            string gameGoal = String.Empty;
            for (int i = 0; i < 4; i++)
            {
                string randomDigit = numberGenerator.Next(10).ToString();
                while (gameGoal.Contains(randomDigit))
                {
                    randomDigit = numberGenerator.Next(10).ToString();
                }
                gameGoal += randomDigit;
            }
            return gameGoal;
        }

        public string GetBullsAndCows(string gameGoal, string playersGuess)
        {
            int cows = 0, bulls = 0;
            playersGuess += "    ";     // if player entered less than 4 chars,felhantering ska vara bättre
            for (int i = 0; i < 4; i++)//too much iteration
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameGoal[i] == playersGuess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }
        public class PlayerData
        {

            public string PlayerName { get; private set; }
            public int NumberOfGamesPlayed { get; private set; }
            int totalNumberOfGuesses;


            public PlayerData(string name, int guesses)
            {
                this.PlayerName = name;
                NumberOfGamesPlayed = 1;
                totalNumberOfGuesses = guesses;
            }

            public void IncrementTotalNumberOfGuesses(int guesses) => totalNumberOfGuesses += guesses;
            public void IncrementNumberOfGamesPlayed() => NumberOfGamesPlayed++;
            public double CalculateAverageGuessesPerGame() => (double)totalNumberOfGuesses / NumberOfGamesPlayed;
            public override bool Equals(Object player) => PlayerName.Equals(((PlayerData)player).PlayerName);
            public override int GetHashCode() => PlayerName.GetHashCode();
        }
    }
}
