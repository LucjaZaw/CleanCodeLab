using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface IGuessingGame
    {
        string GameName { get; }
        bool GameIsOn { get; set; }
        string GameInstruction { get; }
        int PlayersNumberOfGuesses { get; set; }

        void PlayGame();
        string GetGameGoal();
        string CalculateBullsAndCowsScore(string gameGoal, string playersGuess);
        void DisplayInitialMessage();
        string StartNewGame();
        void PlayRound(string gameGoal);
        
    }
}
