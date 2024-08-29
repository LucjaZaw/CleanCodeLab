using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CleanCodeLab.Classes
{
    public class ProgramController
    {
        private IGuessingGame _gameLogic;
        private IUI _ui;
        private IStatistics _statistics;
        private string _newPlayerMessage = "Enter your user playerName:\n";


        public ProgramController(IGuessingGame gameLogic, IUI ui, IStatistics statistics)
        {
            _gameLogic = gameLogic;
            _ui = ui;
            _statistics = statistics;
        }
        public void Run()
        {
            _ui.DisplayOutput(_newPlayerMessage);
            string playerName = _ui.GetUserInput();

            while (_gameLogic.GameIsOn) 
            {
                _gameLogic.PlayGame();
                HandleGameEnd(playerName, _gameLogic.PlayersNumberOfGuesses);
                _gameLogic.GameIsOn = AskToContinueGame();
            }
        }
        public void HandleGameEnd(string playerName, int numberOfGuesses)
        {
            _statistics.AddPlayerData(playerName, numberOfGuesses);
            List<PlayerData> results = _statistics.GetPlayerData();
            _ui.DisplayOutput(_statistics.CreateTopList(results));
        }
        public bool AskToContinueGame()
        {
            _ui.DisplayOutput("Continue? (y/n)");
            string answer = _ui.GetUserInput();
            return string.IsNullOrEmpty(answer) || answer.Substring(0, 1).ToLower() != "n";
        }
    }
}