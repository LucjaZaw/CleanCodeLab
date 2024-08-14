using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes;

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
