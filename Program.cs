using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            bool gameIsOn = true;
            Console.WriteLine("Enter your user playerName:\n");
            string playerName = Console.ReadLine();

            while (gameIsOn)
            {
                string gameGoal = GenerateRandomFourDigitNumber();

                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                //Console.WriteLine("For practice, number is: " + gameGoal + "\n");
                string playersGuess = Console.ReadLine();

                int numberOfGuesses = 1;
                string guessOutcome = GetBullsAndCows(gameGoal, playersGuess);
                Console.WriteLine(guessOutcome + "\n");
                while (guessOutcome != "BBBB,")
                {
                    numberOfGuesses++;
                    playersGuess = Console.ReadLine();
                    Console.WriteLine(playersGuess + "\n");
                    guessOutcome = GetBullsAndCows(gameGoal, playersGuess);
                    Console.WriteLine(guessOutcome + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(playerName + "#&#" + numberOfGuesses);
                output.Close();
                showTopList();
                Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    gameIsOn = false;
                }
            }
        }
        static string GenerateRandomFourDigitNumber()
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
        }

        static string GetBullsAndCows(string gameGoal, string playersGuess)
        {
            int cows = 0, bulls = 0;
            playersGuess += "    ";     // if player entered less than 4 chars,felhantering ska vara bättre
            for (int i = 0; i < 4; i++)//too much iteration
            {
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
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }


        static void showTopList()
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
            results.Sort((p1, p2) => p1.CalculateAverageGuessesPerGame().CompareTo(p2.CalculateAverageGuessesPerGame()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.PlayerName, p.NumberOfGamesPlayed, p.CalculateAverageGuessesPerGame()));
            }
            input.Close();
        }
    }

    class PlayerData
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;


        public PlayerData(string name, int guesses)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }


        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}