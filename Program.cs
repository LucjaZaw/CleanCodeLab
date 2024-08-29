using System;
using System.IO;
using System.Collections.Generic;
using CleanCodeLab.Interfaces;
using CleanCodeLab.Classes;

namespace MooGame
{
    class MainClass
    {   
        public static void Main(string[] args)
        {
            IUI ui = new ConsoleIO();
            ICustomRandom customRandom = new MyRandomWrapper(); 
            IStatistics statistics = new Statistics();
            IGuessingGame gameLogic = new MooGameLogic(ui, customRandom);
            ProgramController gameController = new(gameLogic, ui, statistics);
            gameController.Run();
            #region This is the old code
            /*bool GameIsOn = true;
            Console.WriteLine("Enter your user playerName:\n");
            string playerName = Console.ReadLine();

            while (GameIsOn)
            {
                string gameGoal = GetGameGoal();

                Console.WriteLine("New game:\n Guess a 4 digit number");
                //comment out or remove next line to play real games!
                //Console.WriteLine("For practice, number is: " + gameGoal + "\n");
                string playersGuess = Console.ReadLine();

                int PlayersNumberOfGuesses = 1;
                string guessOutcome = CalculateBullsAndCowsScore(gameGoal, playersGuess);
                Console.WriteLine(guessOutcome + "\n");
                while (guessOutcome != "BBBB,")
                {
                    PlayersNumberOfGuesses++;
                    playersGuess = Console.ReadLine();
                    Console.WriteLine(playersGuess + "\n");
                    guessOutcome = CalculateBullsAndCowsScore(gameGoal, playersGuess);
                    Console.WriteLine(guessOutcome + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + PlayersNumberOfGuesses);
                output.Close();
                showTopList();
                Console.WriteLine("Correct, it took " + PlayersNumberOfGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    GameIsOn = false;
                }
            }
        }*/
            /*static string GetGameGoal()
            {
                Random numberGenerator = new Random();
                string gameGoal = String.Empty;
                for (int i = 0; i < 4; i++)
                {
                    string randomDigit = numberGenerator.Next(10).ToString(); 
                    while (gameGoal.Contains(randomDigit))
                    {
                        randomDigit = numberGenerator.Next(10).ToString();
                    }
                    gameGoal += randomDigit;
                }
                return gameGoal;
            }*/
            /*static string CalculateBullsAndCowsScore(string gameGoal, string playersGuess)
            {
                int cows = 0, bulls = 0;
                playersGuess += "    ";     // if player entered less than 4 chars,felhantering ska vara bättre
                for (int i = 0; i < 4; i++)//too much iteration
                {
                    //goal 1598
                    //guess 4568
                    for (int j = 0; j < 4; j++)
                    {
                        if (gameGoal[i] == playersGuess[j])
                        {
                            if (i == j) 
                            {
                                bulls++;
                            }
                            else
                            {
                                cows++;
                            }
                        }
                    }
                }
                return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);*/
        }
        /*static void showTopList()
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
                    results[pos].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.GameName, p.NumberOfGamesPlayed, p.Average()));
            }
            input.Close();*/
    }
}

    /*class PlayerData
    {
        public string GameName { get; private set; }
        public int NumberOfGamesPlayed { get; private set; }
        int totalGuess;


        public PlayerData(string name, int guesses)
        {
            this.GameName = name;
            NumberOfGamesPlayed = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NumberOfGamesPlayed++;
        }

        public double Average()
        {
            return (double)totalGuess / NumberOfGamesPlayed;
        }


        public override bool Equals(Object p)
        {
            return GameName.Equals(((PlayerData)p).GameName);
        }


        public override int GetHashCode()
        {
            return GameName.GetHashCode();
        }
    }*/
    #endregion