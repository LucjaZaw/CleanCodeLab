using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes;

public class Statistics
{
    
    public void ShowTopList()
    {
        StreamReader input = new StreamReader("result.txt");
        List<PlayerData> results = new List<PlayerData>();
        string line;
        while ((line = input.ReadLine()) != null)
        {
            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string name = nameAndScore[0];
            int guesses = Convert.ToInt32(nameAndScore[1]);
            PlayerData pd = new PlayerData(name, guesses);
            int pos = results.IndexOf(pd);
            if (pos < 0)
            {
                results.Add(pd);
            }
            else
            {
                results[pos].IncrementTotalNumberOfGuesses(guesses);
            }
        }
        results.Sort((p1, p2) => p1.CalculateAverageGuessesPerGame().CompareTo(p2.CalculateAverageGuessesPerGame()));
        Console.WriteLine("Player   games average");
        foreach (PlayerData p in results)
        {
            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfGamesPlayed, p.CalculateAverageGuessesPerGame()));
        }
        input.Close();
    }
}
