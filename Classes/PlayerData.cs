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
    int TotalNumberOfGuesses;


    public PlayerData(string name, int guesses)
    {
        this.PlayerName = name;
        NumberOfGamesPlayed = 1;
        TotalNumberOfGuesses = guesses;
    }

    public void IncrementTotalNumberOfGuesses(int guesses) => TotalNumberOfGuesses += guesses;
    public void IncrementNumberOfGamesPlayed() => NumberOfGamesPlayed++;
    public double CalculateAverageGuessesPerGame() => (double)TotalNumberOfGuesses / NumberOfGamesPlayed;
    public override bool Equals(Object player) => PlayerName.Equals(((PlayerData)player).PlayerName);
    public override int GetHashCode() => PlayerName.GetHashCode();
}
