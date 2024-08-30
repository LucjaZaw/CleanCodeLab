using CleanCodeLab.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces;

public interface IStatistics
{
    public List<PlayerData> GetPlayerData();
    public void AddPlayerData(string playerName, int numberOfGuesses);
    string CreateTopList(List<PlayerData> playerData);
}
