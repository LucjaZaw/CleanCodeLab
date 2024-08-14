using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes
{
    public class ConsoleIO : IUI
    {
        public void EnterPlayerName()
        {
            Console.WriteLine("Enter your user playerName:\n");
        }
        public string GetPlayerName()
        {
            return Console.ReadLine();
        }
        public void EnterPlayerGuess() 
        { 
            Console.WriteLine("New game:\n Guess a 4 digit number");
        }
        public string GetPlayerGuess()
        {
            return Console.ReadLine();
        }
        public void GetExitMessage(string numberOfGuesses)
        {
            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
        }
        public string GetExitGameResponce()
        {
            return Console.ReadLine();
        }
        public void ShowTopList()
        {
            throw new NotImplementedException();
        }
    }
}
