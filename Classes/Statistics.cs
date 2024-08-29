using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes;

public class Statistics : IStatistics

{ 
    public void AddPlayerData(string playerName, int numberOfGuesses)
    {
        StreamWriter output = new StreamWriter("result.txt", append: true);
        output.WriteLine(playerName + "#&#" + numberOfGuesses);
        output.Close();
    }
    
    public List<PlayerData> GetPlayerData()
    {
        StreamReader fileReader = new StreamReader("result.txt");
        List<PlayerData> playerDataList = new List<PlayerData>();
        string currentLine;
        
        while ((currentLine = fileReader.ReadLine()) != null)
        {
            string[] nameAndScoreParts = currentLine.Split(new string[] { "#&#" }, StringSplitOptions.None);
            string playerName = nameAndScoreParts[0];
            int numberOfGuesses = Convert.ToInt32(nameAndScoreParts[1]);
            PlayerData currentPlayerData = new PlayerData(playerName, numberOfGuesses);
         
            int existingPlayerIndex = playerDataList.IndexOf(currentPlayerData);
            if (existingPlayerIndex < 0)
            {
                playerDataList.Add(currentPlayerData);
            }
            else
            {
              
                playerDataList[existingPlayerIndex].IncrementTotalNumberOfGuesses(numberOfGuesses);
                playerDataList[existingPlayerIndex].IncrementNumberOfGamesPlayed();
            }
        }
       
        playerDataList.Sort((player1, player2) => 
            player1.CalculateAverageGuessesPerGame().CompareTo(player2.CalculateAverageGuessesPerGame()));
        fileReader.Close();
        return playerDataList;
    }
    public string CreateTopList(List<PlayerData> playerData) 
    { 
        StringBuilder myStringBuilder = new StringBuilder();
        myStringBuilder.AppendLine("Player   games average");
        foreach (PlayerData player in playerData)
        {
            myStringBuilder.AppendLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.PlayerName, player.NumberOfGamesPlayed, player.CalculateAverageGuessesPerGame()));
        }
        return myStringBuilder.ToString();
    }
}
