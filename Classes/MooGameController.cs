using CleanCodeLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeLab.Classes
{
    public class MooGameController
    {
        private MooGameLogic gameLogic;
        private IUI ui;
        private Statistics statistics;

        public MooGameController(MooGameLogic gameLogic, IUI ui, Statistics statistics)
        {
            this.gameLogic = gameLogic;
            ui = ui;   
            this.statistics = statistics;
        }
        public void Run()
        {
            bool gameIsOn = true;
            Console.WriteLine("Enter your user playerName:\n");
            string playerName = Console.ReadLine();

            while (gameIsOn)
            {
                string gameGoal = gameLogic.GenerateRandomFourDigitNumber();

                Console.WriteLine("New game:\n Guess a 4 digit number");
                //comment out or remove next line to play real games!
                //Console.WriteLine("For practice, number is: " + gameGoal + "\n");
                string playersGuess = Console.ReadLine();

                int numberOfGuesses = 1;
                string guessOutcome = gameLogic.GetBullsAndCows(gameGoal, playersGuess);
                Console.WriteLine(guessOutcome + "\n");
                while (guessOutcome != "BBBB,")
                {
                    numberOfGuesses++;
                    playersGuess = Console.ReadLine();
                    Console.WriteLine(playersGuess + "\n");
                    guessOutcome = gameLogic.GetBullsAndCows(gameGoal, playersGuess);
                    Console.WriteLine(guessOutcome + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + numberOfGuesses);
                output.Close();
                statistics.ShowTopList();
                Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    gameIsOn = false;
                }
            }
        }
    }
}
