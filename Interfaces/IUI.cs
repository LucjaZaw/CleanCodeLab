using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Interfaces
{
    public interface IUI
    {
        void EnterPlayerName();
        string GetPlayerName();
        void EnterPlayerGuess();
        string GetPlayerGuess();
        void GetExitMessage(string numberOfGuesses);
        string GetExitGameResponce();
        void ShowTopList();
    }
}
